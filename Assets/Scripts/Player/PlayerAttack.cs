using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private int damageSize;
    [SerializeField]
    private TypeWeapon typeOfWeapon;

    void Start()
    {

    }

    void Update()
    {
        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonUp(1))
        {
            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
            if (rayHit.collider != null)
            {
                if (typeOfWeapon.Equals(TypeWeapon.STEEL) && Vector2.Distance(transform.position, rayHit.transform.position) < 2)
                {
                    if (rayHit.collider.tag == "Animal")
                    {
                        attack(rayHit);
                    }

                    if (rayHit.collider.tag == "Item")
                    {
                        mineItem(rayHit);
                    }
                }
            }
        }
    }

    public void attack(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        AnimalStatus status = targetGameObject.GetComponent<AnimalStatus>();
        status.hitAnimal(1);
        if (status.Hp <= 0)
        {
            if (null != targetGameObject.GetComponent<Items>())
            {
                mineItem(rayHit);
            }
            status.Die();
        }
    }

    public void mineItem(RaycastHit2D rayHit)
    {
        Inventory inventory = GetComponent<Inventory>();

        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        Items resources = targetGameObject.GetComponent<Items>();
        foreach (MaterialResource resource in resources.ItemList)
        {
            resource.Strength -= damageSize;
            if (resource.Strength <= 0)
            {
                inventory.addItem(resource);
                destroyItemObject(targetGameObject);
            }
        }
    }

    public void destroyItemObject(GameObject gameObject)
    {
        if (null != gameObject.GetComponent<ObjectStatus>())
        {
            gameObject.GetComponent<ObjectStatus>().DestroyObject();
        }
    }

    public enum TypeWeapon { 
        STEEL,
        GUNSHOOT
    }
}

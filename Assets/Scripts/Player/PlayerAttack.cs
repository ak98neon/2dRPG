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
                float distanceToTarget = Vector2.Distance(transform.position, rayHit.transform.position);
                if ((typeOfWeapon.Equals(TypeWeapon.STEEL) && distanceToTarget < 2) || (typeOfWeapon.Equals(TypeWeapon.GUNSHOOT) && distanceToTarget < 8))
                {
                    if (rayHit.collider.tag == "Animal")
                    {
                        attackAnimal(rayHit);
                    }

                    if (rayHit.collider.tag == "Item")
                    {
                        mineItems(rayHit);
                    }

                    if (rayHit.collider.tag == "Resource")
                    {
                        mineResource(rayHit);
                    }

                    if (rayHit.collider.tag == "Enemy")
                    {
                        attackAnotherPlayer(rayHit);
                    }
                }
            }
        }
    }

    public void attackAnotherPlayer(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        StatusPlayer status = targetGameObject.GetComponent<StatusPlayer>();
        status.hpPlayerDamage(damageSize);
    }

    public void attackAnimal(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        AnimalStatus status = targetGameObject.GetComponent<AnimalStatus>();
        status.hitAnimal(1);
        if (status.Hp <= 0)
        {
            if (null != targetGameObject.GetComponent<Items>())
            {
                mineItems(rayHit);
            }
            status.Die();
        }
    }

    public void mineItems(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        ObjectStatus status = targetGameObject.GetComponent<ObjectStatus>();
        status.Hp -= damageSize;
        if (status.Hp <= 0)
        {
            Items resources = targetGameObject.GetComponent<Items>();
            foreach (MaterialResource resource in resources.ItemList)
            {
                addItemToInventory(resource);
                destroyItemObject(targetGameObject);
            }
        }
    }

    public void mineResource(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        ObjectStatus status = targetGameObject.GetComponent<ObjectStatus>();
        status.Hp -= damageSize;
        if (status.Hp <= 0)
        {
            MaterialResource resource = targetGameObject.GetComponent<MaterialResource>();
            addItemToInventory(resource);
            destroyItemObject(targetGameObject);
        }
    }

    public void addItemToInventory(MaterialResource resource)
    {
        Inventory inventory = GetComponent<Inventory>();
        inventory.addItem(resource);
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

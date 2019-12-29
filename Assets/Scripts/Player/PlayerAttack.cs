using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private int damageSize;
    [SerializeField]
    private TypeWeapon typeOfWeapon;
    [SerializeField]
    private Inventory inventory;

    void Start()
    {
        inventory = FindInActiveObjectByTag("InventoryPanel").GetComponent<Inventory>();
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
                        attackObject(rayHit);
                    }

                    if (rayHit.collider.tag == "Resource")
                    {
                        getResource(rayHit);
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

    private void attackObject(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        ObjectStatus status = targetGameObject.GetComponent<ObjectStatus>();
        status.Hp -= damageSize;
        if (status.Hp <= 0)
        {
            mineItems(rayHit);
        }
    }

    public void mineItems(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        Items resources = targetGameObject.GetComponent<Items>();
        foreach (MaterialResource resource in resources.ItemList)
        {
            addItemToInventory(resource);
            destroyItemObject(targetGameObject);
        }
    }

    public void getResource(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        ObjectStatus status = targetGameObject.GetComponent<ObjectStatus>();
        status.Hp -= damageSize;
        if (status.Hp <= 0)
        {
            mineResource(targetGameObject);
        }
    }

    public void mineResource(GameObject targetGameObject)
    {
        MaterialResource resource = targetGameObject.GetComponent<MaterialResource>();
        addItemToInventory(resource);
        destroyItemObject(targetGameObject);
    }

    public void addItemToInventory(MaterialResource resource)
    {
        inventory.addItem(resource);
    }

    public void destroyItemObject(GameObject gameObject)
    {
        if (null != gameObject.GetComponent<ObjectStatus>())
        {
            gameObject.GetComponent<ObjectStatus>().DestroyObject();
        }
    }

    private GameObject FindInActiveObjectByTag(string tag)
    {

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    public enum TypeWeapon { 
        STEEL,
        GUNSHOOT
    }
}

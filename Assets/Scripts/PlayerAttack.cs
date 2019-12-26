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
            if (rayHit.collider != null && rayHit.collider.tag == "Animal")
            {
                if (typeOfWeapon.Equals(TypeWeapon.STEEL) && Vector2.Distance(transform.position, rayHit.transform.position) < 2)
                {
                    attack(rayHit);
                }
            }
        }
    }

    public void attack(RaycastHit2D rayHit)
    {
        GameObject targetGameObject = rayHit.transform.gameObject as GameObject;
        AnimalStatus status = targetGameObject.GetComponent<AnimalStatus>();
        status.hitAnimal(1);
    }

    public enum TypeWeapon { 
        STEEL,
        GUNSHOOT
    }
}

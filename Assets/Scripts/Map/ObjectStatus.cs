using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    [SerializeField]
    private string id;
    [SerializeField]
    private string name;
    [SerializeField]
    private int hp;

    private void Start()
    {
        this.id = newObjectID();
    }

    public string Id { get => id; set => id = value; }

    public string Name { get => name; set => name = value; }
    public int Hp { get => hp; set => hp = value; }

    public ObjectStatus(string name, int hp)
    {
        this.id = System.Guid.NewGuid().ToString();
        this.name = name;
        this.hp = hp;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public string newObjectID()
    {
        return System.Guid.NewGuid().ToString();
    }
}

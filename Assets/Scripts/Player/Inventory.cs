using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<MaterialResource> items = new List<MaterialResource>();

    public List<MaterialResource> Items { get => items; set => items = value; }

    public void addItem(MaterialResource materialResource)
    {
        items.Add(materialResource);
        Debug.Log("Add new item in inventory: " + materialResource.Name + " count: " + materialResource.ResourceCount);
    }

    public void removeItem(MaterialResource materialResource)
    {
        items.Remove(materialResource);
    }
}

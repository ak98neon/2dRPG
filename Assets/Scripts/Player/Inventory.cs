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
        Debug.Log("Add new item: " + materialResource.Name + " count: " + materialResource.ResourceCount);
        items.Add(materialResource);
    }

    public void removeItem(MaterialResource materialResource)
    {
        items.Remove(materialResource);
    }
}

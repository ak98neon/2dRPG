using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<MaterialResource> items = new List<MaterialResource>();
    [SerializeField]
    private InventoryCell _inventoryCellTemplate;
    [SerializeField]
    private Transform container;

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

    private void OnEnable()
    {
        Render(items);
    }

    private void Render(List<MaterialResource> items)
    {
        foreach (Transform child in container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, container);
            cell.Render(item);
        });
    }
}

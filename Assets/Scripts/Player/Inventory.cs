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
    [SerializeField]
    private Transform _draggingParent;

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
            cell.Init(_draggingParent);
            cell.Render(item);

            cell.Ejecting += () => {
                items.Remove(item);
                dropItem(item);
                Destroy(cell.gameObject);
            };
        });
    }

    private void dropItem(MaterialResource material)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Instantiate(material.Prefab, player.transform.position, Quaternion.identity);
        }
    }
}

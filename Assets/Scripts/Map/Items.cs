using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    private List<MaterialResource> itemList = new List<MaterialResource>();

    public List<MaterialResource> ItemList { get => itemList; set => itemList = value; }

    public Items(List<MaterialResource> itemList)
    {
        this.itemList = itemList;
    }
}

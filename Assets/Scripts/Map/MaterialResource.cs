using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialResource : MonoBehaviour, IItem
{
    [SerializeField]
    private string name;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int resourceCount;
    [SerializeField]
    private int strength;
    [SerializeField]
    private Sprite icon;

    public string Name { get => name; set => name = value; }
    public GameObject Prefab { get => prefab; set => prefab = value; }
    public int ResourceCount { get => resourceCount; set => resourceCount = value; }
    public int Strength { get => strength; set => strength = value; }
    public Sprite Icon { get => icon; set => icon = value; }

    public MaterialResource(string name, GameObject prefab, int resourceCount, int strength, Sprite icon)
    {
        this.name = name;
        this.prefab = prefab;
        this.resourceCount = resourceCount;
        this.strength = strength;
        this.icon = icon;
    }

    public void DestroyResource()
    {
        Destroy(gameObject);
    }
}

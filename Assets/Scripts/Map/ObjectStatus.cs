using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectStatus : MonoBehaviour
{
    [SerializeField]
    private string id;
    [SerializeField]
    private string name;
    [SerializeField]
    private int hp;

    private Text materialInfoText;

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

    public void OnMouseOver()
    {
        materialInfoText = FindInActiveObjectByTag("MaterialInfo").GetComponent<Text>();
        if (null != materialInfoText)
        {
            materialInfoText.gameObject.SetActive(true);
            materialInfoText.text = name;
            materialInfoText.transform.position = Input.mousePosition;
        }
    }

    private void OnDestroy()
    {
        materialInfoText.gameObject.SetActive(false);
    }

    private void OnMouseExit()
    {
        materialInfoText.gameObject.SetActive(false);
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
}

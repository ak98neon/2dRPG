using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    private GameObject panel;

    void Start()
    {
        panel = FindInActiveObjectByTag("InventoryPanel");
        panel.SetActive(false);
    }

    void Update()
    {
        if (null != panel && Input.GetKeyDown(KeyCode.I))
        {
            bool isActivePanel = panel.activeSelf;
            panel.SetActive(!isActivePanel);
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
}

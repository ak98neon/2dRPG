using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Image _iconImage;

    public void Render(IItem item)
    {
        _text.text = item.Name;
        _iconImage.sprite = item.Icon;
    }
}

public interface IItem { 
    string Name { get; }
    Sprite Icon { get;  }
}

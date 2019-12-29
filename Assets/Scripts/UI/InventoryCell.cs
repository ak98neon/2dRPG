using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public event System.Action Ejecting;

    [SerializeField] private Text _text;
    [SerializeField] private Image _iconImage;

    private Transform _draggingParent;
    private Transform _originalParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _draggingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (In((RectTransform)_originalParent))
        {
            insertInGrid();
        } else
        {
            Eject();
        }
    }

    private bool In(RectTransform originalParent)
    {
        return originalParent.rect.Contains(transform.position);
    }

    private void Eject()
    {
        Ejecting?.Invoke();
    }

    private void insertInGrid()
    {
        int closesIndex = 0;

        for (int i = 0; i < _originalParent.transform.childCount; i++)
        {
            if (Vector3.Distance(transform.position, _originalParent.GetChild(i).position) <
                Vector3.Distance(transform.position, _originalParent.GetChild(closesIndex).position))
            {
                closesIndex = i;
            }
        }

        transform.parent = _originalParent;
        transform.SetSiblingIndex(closesIndex);
    }

    public void Init(Transform draggingParent)
    {
        _draggingParent = draggingParent;
        _originalParent = transform.parent;
    }

    public void Render(IItem item)
    {
        _text.text = item.Name;
        _iconImage.sprite = item.Icon;
        _iconImage.preserveAspect = true;
    }
}

public interface IItem { 
    string Name { get; }
    Sprite Icon { get;  }
}

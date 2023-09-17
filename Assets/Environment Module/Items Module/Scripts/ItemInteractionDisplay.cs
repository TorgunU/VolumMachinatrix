using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class ItemInteractionDisplay : MonoBehaviour
{
    [SerializeField] private ItemInteractableTextDisplay _textDisplay;
    [SerializeField] private Color _selectColor;

    private Item _selectedItem;
    private ItemInteractionEffectDisplay _effectDisplay;

    private void Awake()
    {
        _effectDisplay = new ItemInteractionEffectDisplay(_selectColor);
    }

    public void OnSelected(Item item)
    {
        _selectedItem = item;

        PutAbove(item.transform.position);
        _textDisplay.Select(item.transform);
        _effectDisplay.Select(item.GetComponent<SpriteRenderer>());
    }

    public void OnDeselected()
    {
        PutBelow(_selectedItem.transform.position);

        _textDisplay.Deselect();
        _effectDisplay.Deselect();

        //_selectedItem = null;
    }

    private void PutAbove(Vector3 itemPosition)
    {
        itemPosition = new Vector3(
            itemPosition.x,
            itemPosition.y,
            49);

        _selectedItem.transform.position = itemPosition;
    }

    private void PutBelow(Vector3 itemPosition)
    {
        itemPosition = new Vector3(
            itemPosition.x,
            itemPosition.y,
            50);

        _selectedItem.transform.position = itemPosition;
    }
}

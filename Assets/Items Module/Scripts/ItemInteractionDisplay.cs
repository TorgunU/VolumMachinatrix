using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class ItemInteractionDisplay : MonoBehaviour
{
    [SerializeField] private ItemInteractableTextDisplay _textDisplay;
    [SerializeField] private Color _selectColor;

    private ItemInteractionEffectDisplay _effectDisplay;

    private void Awake()
    {
        _effectDisplay = new ItemInteractionEffectDisplay(_selectColor);
    }

    public void OnSelected(Item item)
    {
        _textDisplay.Select(item.transform);
        _effectDisplay.Select(item.GetComponent<SpriteRenderer>());
    }

    public void OnDeselected()
    {
        _textDisplay.Deselect();
        _effectDisplay.Deselect();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractionEffectDisplay
{
    private Color _highlightColor;

    private Color _defaultColor;
    //private Item _currentItem;
    private SpriteRenderer _currentItemSpriteRenderer;

    public ItemInteractionEffectDisplay(Color highlightColor)
    {
        _highlightColor = highlightColor;
    }

    public void Select(SpriteRenderer itemSpriteRenderer)
    {
        _currentItemSpriteRenderer = itemSpriteRenderer;
        _defaultColor = _currentItemSpriteRenderer.color;

        Highlight();
    }

    public void Deselect()
    {
        ResetHightlight();
    }

    private void Highlight()
    {
        _currentItemSpriteRenderer.color = _highlightColor;
    }

    private void ResetHightlight()
    {
        _currentItemSpriteRenderer.color = _defaultColor;
    }
}
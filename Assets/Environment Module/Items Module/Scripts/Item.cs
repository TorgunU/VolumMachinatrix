using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemConfig _itemConfig;

    protected bool IsStackable;
    protected SpriteRenderer SpriteRenderer;
    private string _label;
    private ItemType _itemType;

    protected virtual void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = _itemConfig.Sprite;

        IsStackable = _itemConfig.IsStackable;
        _itemType = _itemConfig.ItemType;
        _label = _itemConfig.Label;
    }

    public abstract void Use();
    public abstract void Pickup();

    public ItemType ItemType { get => _itemType; }
}

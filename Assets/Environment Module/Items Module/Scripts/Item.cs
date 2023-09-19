using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemConfig _itemConfig;

    protected SpriteRenderer SpriteRenderer;

    private Sprite _sprite;
    private bool _isStackable;
    private string _label;
    private ItemType _itemType;

    protected virtual void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = _itemConfig.Sprite;

        _sprite = _itemConfig.Sprite;

        _isStackable = _itemConfig.IsStackable;
        _itemType = _itemConfig.ItemType;
        _label = _itemConfig.Label;
    }

    public abstract void Pickup();

    public ItemType ItemType { get => _itemType; }
    public Sprite Sprite { get => _sprite; }
}

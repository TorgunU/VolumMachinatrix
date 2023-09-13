using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemConfig _itemConfig;

    protected bool IsStackable;
    private string _label;
    private ItemType _itemType;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _itemConfig.Sprite;

        IsStackable = _itemConfig.IsStackable;
        _itemType = _itemConfig.ItemType;
        _label = _itemConfig.Label;
    }

    protected abstract void OnTriggerStay2D(Collider2D collision);

    public abstract void Use();
    public abstract void Pickup();

    public ItemType ItemType { get => _itemType; }
}
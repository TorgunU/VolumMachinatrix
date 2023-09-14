using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Config",
    menuName = "ScriptableObjects/Items/Default Item", order = 52)]
public class ItemConfig : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private bool _stackable = true;

    public string Label { get => _label;}
    public Sprite Sprite { get => _sprite; }
    public ItemType ItemType { get => _itemType;}
    public bool IsStackable { get => _stackable;}
}

public enum ItemType
{
    Weapon,
    Ammo,
    Useable
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Config",
    menuName = "ScriptableObjects/Items/Default Item", order = 52)]
public class ItemConfig : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private InteractableType _interactableType;
    [SerializeField] private bool _stackable = true;

    public Sprite Sprite { get => _sprite; }
    public ItemType ItemType { get => _itemType;}
    public InteractableType InteractableType { get => _interactableType; }
    public bool Stackable { get => _stackable;}
}

public enum ItemType
{
    Weapon,
    Ammo,
    Stimulator
}

public enum InteractableType
{
    Switching,
    Using
}

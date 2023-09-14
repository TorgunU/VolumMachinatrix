using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemViewer _firstItemViewer;

    public void OnFirstItemsSlotChanged(Sprite itemSprite, int itemsCount)
    {
        _firstItemViewer.UpdateViewer(itemSprite, itemsCount);
    }
}

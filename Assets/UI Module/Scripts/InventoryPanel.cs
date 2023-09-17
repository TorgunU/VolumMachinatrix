using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemViewer _firstItemViewer;
    // weapon slot
    // other slots items

    public void OnFirstSlotSetted(Sprite itemSprite, int itemsCount)
    {
        _firstItemViewer.SetViewer(itemSprite, itemsCount);
    }

    public void OnFirstSlotUpdated(int itemsCount)
    {
        _firstItemViewer.UpdateViewer(itemsCount);
    }

    public void OnFirstSlotResseted()
    {
        _firstItemViewer.ResetViewer();
    }
}

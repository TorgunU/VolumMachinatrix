using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerItemInteractible : 
    IItemUsable, 
    IItemTakeable, IItemDropeable,
    IItemSwitchable
{

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryManipulationEvents
{
    public event Action FirstWeaponSlotPressed;
    public event Action FirstSlotItemsPressed;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemInteractionEvents
{
    public abstract event Action PickupPressed;
    public abstract event Action UsePressed;
    public abstract event Action SwitchPressed;
    public abstract event Action DropPressed;
}

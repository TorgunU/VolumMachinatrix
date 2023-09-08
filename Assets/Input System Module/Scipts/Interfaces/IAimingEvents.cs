using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimingEvents
{
    public event Action<bool> AimHolded;
}

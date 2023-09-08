using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementStateEvents
{
    public abstract event Action<bool> RunStateChanged;
    public abstract event Action<bool> WalkStateChanged;
}

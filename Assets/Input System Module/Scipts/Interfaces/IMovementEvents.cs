using System;
using UnityEngine;

public interface IMovementEvents
{
    public event Action<bool> RunStateChanged;
    public event Action<bool> WalkStateChanged;
    public event Action<Vector2> MovementDirectionUpdated;
}
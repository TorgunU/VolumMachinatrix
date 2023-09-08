using System;
using UnityEngine;

public interface IMovementDirection
{
    public event Action<Vector2> MovementDirectionUpdated;
}
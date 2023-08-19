using System;
using UnityEngine;

public interface ILookDirectionEvents
{
    public event Action<Vector2> LookDirectionUpdated;
}
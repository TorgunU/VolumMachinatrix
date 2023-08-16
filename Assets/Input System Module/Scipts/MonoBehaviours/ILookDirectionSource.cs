using System;
using UnityEngine;

public interface ILookDirectionSource
{
    public event Action<Vector2> LookDirectionUpdated;
}
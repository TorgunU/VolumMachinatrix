using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILegRotaionLimiter
{
    public void Rotate(Vector2 inputDirection);
    public float GetLegsRoationAngle();
}
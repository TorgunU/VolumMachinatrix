using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITorsoRotaionLimiter
{
    public void CheckTorsoAngleLimit(Vector2 torsoAngle);
}

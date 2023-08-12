using System.Runtime.CompilerServices;
using UnityEngine;

public class Legs : MonoBehaviour, ITorsoRotaionLimiter
{
    private Vector2 _direction;

    private void Rotate()
    {
        if (_direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(-_direction.x, _direction.y) * Mathf.Rad2Deg;

            if (angle < -90 || angle > 90)
            {
                angle += 180;

            }
            else
            {
                angle = Mathf.Clamp(angle, -75, 75);
            }

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Debug.DrawRay(transform.position, _direction, Color.yellow);
        }
    }

    public void CheckTorsoAngleLimit(Vector2 torsoAngle)
    {
        _direction = torsoAngle;

        Rotate();
    }
}
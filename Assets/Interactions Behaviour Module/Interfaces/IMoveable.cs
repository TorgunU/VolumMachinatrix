using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public void Move();
    public void SetDirection(Vector2 moveDirection);
}

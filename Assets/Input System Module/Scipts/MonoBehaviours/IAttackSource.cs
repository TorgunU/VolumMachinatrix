using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackSource 
{
    public event Action<bool> AttackPressed;
}

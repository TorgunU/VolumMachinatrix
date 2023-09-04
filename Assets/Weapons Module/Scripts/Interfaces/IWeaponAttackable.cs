using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponAttackable : IAttackeable
{
    public IEnumerator CalculatingAttackDelay();

}
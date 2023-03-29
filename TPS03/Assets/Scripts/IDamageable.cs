using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void OnDamage(float damage, Vector3 hitPosition, Vector3 hitNormal);
}
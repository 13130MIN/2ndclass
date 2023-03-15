using System;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{
    void OnDamage(float damage, Vector3 hitPosition, Vector3 hitNormal);
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{
    void OnDamage(float damage, Vector2 hitPos, Vector3 hitNormal);
}

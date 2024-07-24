using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public Vector3 Origin { get; private set; }
    public int DamageAmount { get; private set; }
    public float PushForce { get; private set; }

    public Damage(Vector3 origin, int damageAmount, float pushForce)
    {
        Origin = origin;
        DamageAmount = damageAmount;
        PushForce = pushForce;
    }
}

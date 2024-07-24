using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _pushForce = 5;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Fighter") && coll.name == "Player")
        {
            var dmg = new Damage(transform.position, _damage,  _pushForce);
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] protected int _hitpoint = 10;
    [SerializeField] protected int _maxHitpoint = 10;
    [SerializeField] protected float _pushRecoverySpeed = 0.2f;
    protected float _immuneTime = 1f;
    protected float _lastImmune;
    protected Vector3 _pushDirection;

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - _lastImmune > _immuneTime)
        {
            _lastImmune = Time.time;
            _hitpoint -= dmg.DamageAmount;
            _pushDirection = (transform.position - dmg.Origin).normalized * dmg.PushForce;

            var msg = dmg.DamageAmount.ToString();
            var fontSize = 25;
            var color = Color.red;
            var pos = transform.position;
            var motion = Vector3.zero;
            var duration = 0.5f;
            GameManager.Instance.ShowText(msg, fontSize, color, pos, motion, duration);

            if (_hitpoint <= 0)
            {
                _hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        
    }
}

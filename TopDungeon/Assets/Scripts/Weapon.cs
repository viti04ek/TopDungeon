using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    public int DamagePoint { get; private set; } = 1;
    public float PushForce { get; private set; } = 2f;
    public int WeaponLevel { get; set; } = 0;
    private SpriteRenderer _spriteRenderer;
    private float _cooldown = 0.5f;
    private float _lastSwing;

    protected override void Start()
    {
        base.Start();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
            TryToSwing();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Fighter") && coll.name != "Player")
        {
            var dmg = new Damage(transform.position, DamagePoint, PushForce);
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void TryToSwing()
    {
        if (Time.time - _lastSwing > _cooldown)
        {
            _lastSwing = Time.time;
            Swing();
        }
    }

    private void Swing()
    {
        Debug.Log("Swing");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    [SerializeField] private int _damagePoint = 1;
    [SerializeField] private float _pushForce = 2f;
    public int WeaponLevel { get; set; } = 0;
    private SpriteRenderer _spriteRenderer;
    private float _cooldown = 0.5f;
    private float _lastSwing;
    private Animator _anim;
    private const string _triggerName = "Swing";

    protected override void Start()
    {
        base.Start();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
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
            var dmg = new Damage(transform.position, _damagePoint, _pushForce);
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
        _anim.SetTrigger(_triggerName);
    }
}

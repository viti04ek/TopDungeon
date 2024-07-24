using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    [SerializeField] private int _xpValue = 1;
    [SerializeField] private float _triggerLenght = 1f;
    [SerializeField] private float _chaseLenght = 5f;
    [SerializeField] private ContactFilter2D _filter;
    private bool _chasing;
    private bool _collidingWithPlayer;
    private Transform _playerTransform;
    private Vector3 _startingPosition;
    private BoxCollider2D _hitbox;
    private Collider2D[] _hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        _playerTransform = GameManager.Instance.Player.transform;
        _startingPosition = transform.position;
        _hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        Chasing();
        IsCollidingWithPlayer();
    }

    protected override void Death()
    {
        GameManager.Instance.Experience += _xpValue;
        var msg = $"+{_xpValue} xp";
        var fontSize = 30;
        var color = Color.magenta;
        var pos = transform.position;
        var motion = Vector3.up * 40;
        var duration = 1f;
        GameManager.Instance.ShowText(msg, fontSize, color, pos, motion, duration);
        Destroy(gameObject);
    }

    private void Chasing()
    {
        if (Vector3.Distance(_playerTransform.position, _startingPosition) < _chaseLenght)
        {
            if (Vector3.Distance(_playerTransform.position, _startingPosition) < _triggerLenght)
                _chasing = true;
            
            if (_chasing)
            {
                if (!_collidingWithPlayer)
                {
                    UpdateMotor((_playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(_startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(_startingPosition - transform.position);
            _chasing = false;
        }
    }

    private void IsCollidingWithPlayer()
    {
        _collidingWithPlayer = false;
        _boxCollider.OverlapCollider(_filter, _hits);
        for (var i = 0; i < _hits.Length; i++)
        {
            if (_hits[i] == null)
                continue;

            if (_hits[i].CompareTag("Fighter") && _hits[i].name == "Player")
                _collidingWithPlayer = true;
            
            _hits[i] = null;
        }
    }
}

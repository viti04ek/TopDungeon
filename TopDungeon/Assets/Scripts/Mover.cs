using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D _boxCollider;
    protected Vector3 _moveDelta;
    protected RaycastHit2D _hit;
    protected float _ySpeed = 0.75f;
    protected float _xSpeed = 1f;

    protected virtual void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        _moveDelta = new(input.x * _xSpeed, input.y * _ySpeed, 0);

        if (_moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x < 0)
            transform.localScale = new(-1, 1, 1);

        _moveDelta += _pushDirection;
        _pushDirection = Vector3.Lerp(_pushDirection, Vector3.zero, _pushRecoverySpeed);
        
        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new(0, _moveDelta.y),
            Mathf.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (_hit.collider == null)
            transform.Translate(0, _moveDelta.y * Time.deltaTime, 0);
        
        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new(_moveDelta.x, 0),
            Mathf.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (_hit.collider == null)
            transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);
    }
}

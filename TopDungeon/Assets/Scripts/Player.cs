using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    private BoxCollider2D _boxCollider;
    private Vector3 _moveDelta;
    private RaycastHit2D _hit;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
        MovePlayer();
    }

    private void RotatePlayer()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        _moveDelta = new(x, y, 0);

        if (_moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x < 0)
            transform.localScale = new(-1, 1, 1);
    }

    private void MovePlayer()
    {
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

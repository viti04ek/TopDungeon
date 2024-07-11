using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _boxCollider;

    private Vector3 _moveDelta;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        _moveDelta = new(x, y, 0);

        if (_moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x < 0)
            transform.localScale = new(-1, 1, 1);
        
        transform.Translate(_moveDelta * Time.deltaTime);
    }
}

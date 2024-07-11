using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    [SerializeField] private Transform _lookAt;
    [SerializeField] private float _boundX = 0.15f;
    [SerializeField] private float _boundY = 0.05f;

    private void LateUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        var delta = Vector3.zero;
        
        var deltaX = _lookAt.position.x - transform.position.x;
        if (deltaX > _boundX || deltaX < -_boundX)
        {
            if (transform.position.x < _lookAt.position.x)
            {
                delta.x = deltaX - _boundX;
            }
            else
            {
                delta.x = deltaX + _boundX;
            }
        }
        
        var deltaY = _lookAt.position.y - transform.position.y;
        if (deltaY > _boundY || deltaY < -_boundY)
        {
            if (transform.position.y < _lookAt.position.y)
            {
                delta.y = deltaY - _boundY;
            }
            else
            {
                delta.y = deltaY + _boundY;
            }
        }

        transform.position += delta;
    }
}

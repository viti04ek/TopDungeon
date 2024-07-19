using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    [SerializeField] private Sprite _emptyChest;
    [SerializeField] private int _pesosAmount = 5;
    
    protected override void OnCollect()
    {
        if (!_collected)
        {
            _collected = true;
            GetComponent<SpriteRenderer>().sprite = _emptyChest;
            Debug.Log($"Grant {_pesosAmount} pesos");
        }
    }
}

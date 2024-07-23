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
            
            var msg = $"+{_pesosAmount} pesos!";
            var fontSize = 25;
            var color = Color.yellow;
            var pos = transform.position;
            var motion = Vector3.up * 25;
            var duration = 1.5f;
            GameManager.Instance.ShowText(msg, fontSize, color, pos, motion, duration);
        }
    }
}

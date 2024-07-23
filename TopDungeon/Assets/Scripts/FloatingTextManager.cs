using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    private GameObject _textContainer;
    private GameObject _textPrefab;
    private List<FloatingText> _floatingTexts = new();

    private void Update()
    {
        foreach (var txt in _floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }

    private FloatingText GetFloatingText()
    {
        var txt = _floatingTexts.Find(t => !t.GetActive());

        if (txt == null)
        {
            txt = new FloatingText();
            txt.SetGo(Instantiate(_textPrefab));
            txt.GetGo().transform.SetParent(_textContainer.transform);
            txt.SetText(txt.GetGo().GetComponent<Text>());
            
            _floatingTexts.Add(txt);
        }

        return txt;
    }

    public void Show(string msg, int fontSize, Color color, Vector3 pos, Vector3 motion, float duration)
    {
        var txt = GetFloatingText();

        txt.GetText().text = msg;
        txt.GetText().fontSize = fontSize;
        txt.GetText().color = color;
        txt.GetGo().transform.position = Camera.main.WorldToScreenPoint(pos);
        txt.SetMotion(motion);
        txt.SetDuration(duration);
        
        txt.Show();
    }
}

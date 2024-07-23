using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    private GameObject _go;
    private Text _txt;
    private Vector3 _motion;
    private float _duration;
    private float _lastShown;
    private bool _active;

    public void UpdateFloatingText()
    {
        if (!_active)
            return;
        
        if (Time.time - _lastShown > _duration)
            Hide();

        _go.transform.position += _motion * Time.deltaTime;
    }

    public void Show()
    {
        _active = true;
        _lastShown = Time.time;
        _go.SetActive(true);
    }

    public void Hide()
    {
        _active = false;
        _go.SetActive(false);
    }
}

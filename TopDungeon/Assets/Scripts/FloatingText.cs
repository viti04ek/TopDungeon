using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    private GameObject _go;
    private Text _text;
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
    
    public bool GetActive() => _active;

    public GameObject GetGo() => _go;

    public void SetGo(GameObject newGo) => _go = newGo;

    public Text GetText() => _text;

    public void SetText(Text newText) => _text = newText;

    public void SetMotion(Vector3 newMotion) => _motion = newMotion;

    public void SetDuration(float newDuration) => _duration = newDuration;
}

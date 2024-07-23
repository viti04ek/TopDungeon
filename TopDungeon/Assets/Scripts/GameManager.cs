using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Sprite> PlayerSprites;
    public List<Sprite> WeaponSprites;
    public List<int> WeaponPrices;
    public List<int> XPTable;

    public Player Player;
    public FloatingTextManager FloatingTextManager;

    public int Pesos;
    public int Experience;

    private const string _saveKey = "SaveState";
    private const char _splitCh = '|';

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }
    
    /*
     * INT PreferedSkin
     * INT Pesos
     * INT Experience
     * INT WeaponLevel
     */
    public void SaveState()
    {
        var s = "";

        s += "0" + "|";
        s += $"{Pesos}|";
        s += $"{Experience}|";
        s += "0";
        
        PlayerPrefs.SetString(_saveKey, s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey(_saveKey))
            return;
        
        var data = PlayerPrefs.GetString(_saveKey).Split(_splitCh);

        Pesos = int.Parse(data[1]);
        Experience = int.Parse(data[2]);
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 pos, Vector3 motion, float duration)
    {
        FloatingTextManager.Show(msg, fontSize, color, pos, motion, duration);
    }
}

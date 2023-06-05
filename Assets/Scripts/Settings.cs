using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Settings : object
{
    public static KeyCode moveUp = KeyCode.W;
    public static KeyCode moveLeft = KeyCode.A;
    public static KeyCode moveRight = KeyCode.D;
    public static KeyCode use = KeyCode.E;
    public static KeyCode restart = KeyCode.R;

    private static string settingsPath = Application.dataPath + "/Data/Settings.txt";

    public static void resetSettings()
    {
        moveUp = KeyCode.W;
        moveLeft = KeyCode.A;
        moveRight = KeyCode.D;
        use = KeyCode.E;
        restart = KeyCode.R;
    }

    public static void saveSettings() 
    {
        SettingsSave settings = new SettingsSave() { moveUp = moveUp, moveLeft = moveLeft, moveRight = moveRight, use = use, restart = restart };
        string json = JsonUtility.ToJson(settings);
        File.WriteAllText(settingsPath, json);
    }

    public static void loadSettings()
    {
        if (File.Exists(settingsPath))
        {
            string json = File.ReadAllText(settingsPath);
            SettingsSave settings = JsonUtility.FromJson<SettingsSave>(json);
            moveUp = settings.moveUp;
            moveLeft = settings.moveLeft;
            moveRight = settings.moveRight;
            use = settings.use;
            restart = settings.restart;
        } else
        {
            resetSettings();
        }
    }
}

[Serializable]
public class SettingsSave
{
    [SerializeField]
    public KeyCode moveUp;
    [SerializeField]
    public KeyCode moveLeft;
    [SerializeField]
    public KeyCode moveRight;
    [SerializeField]
    public KeyCode use;
    [SerializeField]
    public KeyCode restart;
}

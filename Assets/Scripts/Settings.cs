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

    private static string settingsPath = Application.dataPath + "/Data/Settings.txt";

    public static void resetSettings()
    {
        moveUp = KeyCode.W;
        moveLeft = KeyCode.A;
        moveRight = KeyCode.D;
    }

    public static void saveSettings() 
    {
        SettingsSave settings = new SettingsSave() { moveUp = moveUp, moveLeft = moveLeft, moveRight = moveRight };
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
}

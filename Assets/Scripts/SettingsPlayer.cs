using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;

public class SettingsPlayer : MonoBehaviour
{
    public TMP_Text up;
    public TMP_Text left;
    public TMP_Text right;
    public TMP_Text use;
    public TMP_Text restart;

    void Start()
    {
        Settings.loadSettings();        
        SetKeyCodeButtons();
    }

    private void SetKeyCodeButtons()
    {
        up.text = Settings.moveUp.ToString();
        left.text = Settings.moveLeft.ToString();
        right.text = Settings.moveRight.ToString();
        use.text = Settings.use.ToString();
        restart.text = Settings.restart.ToString();
    }

    public void ResetSettings()
    {
        Settings.resetSettings();
        SetKeyCodeButtons();
    }

    public void Change(string key)
    {
        StartCoroutine(SetButton(key));
    }

    IEnumerator SetButton(string key)
    {
        KeyCode keyCodeBut = KeyCode.Space;
        TMP_Text textBut = null;
        yield return new WaitUntil(() =>
        {
            if (key == "up")
            {
                textBut = up;
                keyCodeBut = Settings.moveUp;
            }
            if (key == "right")
            {
                textBut = right;
                keyCodeBut = Settings.moveRight;
            }
            if (key == "left")
            {
                textBut = left;
                keyCodeBut = Settings.moveLeft;
            }
            if (key == "use")
            {
                textBut = use;
                keyCodeBut = Settings.use;
            }
            if (key == "restart")
            {
                textBut = restart;
                keyCodeBut = Settings.restart;
            }
            textBut.text = "ֽאזלטעו";
            if (Input.anyKeyDown)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    textBut.text = keyCodeBut.ToString();
                    return true;
                }
                Array keyCodes = Enum.GetValues(typeof(KeyCode));
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKey(keyCode))
                    {
                        if (key == "up")
                        {
                            Settings.moveUp = keyCode;
                            up.text = keyCode.ToString();
                            return true;
                        }
                        if (key == "right")
                        {
                            Settings.moveRight = keyCode;
                            right.text = keyCode.ToString();
                            return true;
                        }
                        if (key == "left")
                        {
                            Settings.moveLeft = keyCode;
                            left.text = keyCode.ToString();
                            return true;
                        }
                        if (key == "use")
                        {
                            Settings.use = keyCode;
                            use.text = keyCode.ToString();
                            return true;
                        }
                        if (key == "restart")
                        {
                            Settings.restart = keyCode;
                            restart.text = keyCode.ToString();
                            return true;
                        }
                        return true;

                    }
                }
                return true;
            }
            return false;
        });
    }

    private void OnDestroy()
    {
        Settings.saveSettings();
    }

    public void QuitGame()
    {
        Settings.saveSettings();
        Application.Quit();
    }
}

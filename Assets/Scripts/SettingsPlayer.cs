using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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

    public void Change(String but)
    {
        StartCoroutine(SetButton(but));
    }

    IEnumerator SetButton(string button)
    {
        yield return new WaitUntil(() => {
            if (Input.anyKeyDown) {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    return true;
                }
                Array keyCodes = Enum.GetValues(typeof(KeyCode));
                foreach (KeyCode keyCode in keyCodes) {
                    if (Input.GetKey(keyCode)) {
                        if (button == "up") {
                            Settings.moveUp = keyCode;
                            up.text = keyCode.ToString();
                            return true;
                        }
                        if (button == "right") {
                            Settings.moveRight = keyCode;
                            right.text = keyCode.ToString();
                            return true;
                        }
                        if (button == "left") {
                            Settings.moveLeft = keyCode;
                            left.text = keyCode.ToString();
                            return true;
                        }
                        if (button == "use")
                        {
                            Settings.use = keyCode;
                            use.text = keyCode.ToString();
                            return true;
                        }
                        if (button == "restart")
                        {
                            Settings.restart = keyCode;
                            restart.text = keyCode.ToString();
                            return true;
                        }
                    }
                }
                return true;
            }
            return false;
        });
    }

    public void QuitGame()
    {
        Settings.saveSettings();
        Application.Quit();
    }
}

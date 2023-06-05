using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public TMP_Text ErrorObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Settings.saveSettings();
            Application.Quit();
        }
    }

    public void GotoLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void GotoLevel2()
    {
        if (PlayerPrefs.GetInt("openLevel") >= 2)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            StartCoroutine(printError("Закрыто!"));
        }
    }

    public void GotoLevel3()
    {
        if (PlayerPrefs.GetInt("openLevel") >= 3)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            StartCoroutine(printError("Закрыто!"));
        }
    }

    public void GotoLevel4()
    {
        if (PlayerPrefs.GetInt("openLevel") >= 4)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            StartCoroutine(printError("Закрыто!"));
        }
    }

    public void GotoLevel5()
    {
        if (PlayerPrefs.GetInt("openLevel") >= 5)
        {
            SceneManager.LoadScene(5);
        } 
        else
        {
            StartCoroutine(printError("Закрыто!"));
        }
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator printError(string textError)
    {
        ErrorObject.text = textError;
        ErrorObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        ErrorObject.gameObject.SetActive(false);
    }
}

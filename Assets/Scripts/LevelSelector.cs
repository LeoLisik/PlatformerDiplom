using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    void Start()
    {
        //Settings.loadSettings();
    }

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
        SceneManager.LoadScene(2);
    }

    public void GotoLevel3()
    {
        SceneManager.LoadScene(3);
    }

    public void GotoLevel4()
    {
        SceneManager.LoadScene(4);
    }

    public void GotoLevel5()
    {
        SceneManager.LoadScene(5);
    }

    public void GotoLevel6()
    {
        SceneManager.LoadScene(6);
    }

    public void GotoLevel7()
    {
        SceneManager.LoadScene(7);
    }

    public void GotoLevel8()
    {
        SceneManager.LoadScene(8);
    }

    public void GotoLevel9()
    {
        SceneManager.LoadScene(9);
    }

    public void GotoLevel10()
    {
        SceneManager.LoadScene(10);
    }
}

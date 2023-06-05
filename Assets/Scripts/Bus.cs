using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bus : MonoBehaviour
{
    public int payment = 0;
    public void startExit()
    {
        this.GetComponent<AudioSource>().Play();
        StartCoroutine(exit());
    }

    IEnumerator exit()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 pos = this.transform.position;
            pos.x += 0.1f;
            this.transform.position = pos;
            yield return new WaitForSeconds(0.03f);
        }
        if (PlayerPrefs.GetInt("openLevel") < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("openLevel", SceneManager.GetActiveScene().buildIndex + 1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(0);
    }
}

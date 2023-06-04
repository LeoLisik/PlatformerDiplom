using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    public int boostTime = 0;

    public float speedBoost = 0f;
    public float jumpBoost = 0f;

    // Start is called before the first frame update
    void Start()
    {  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fall()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    IEnumerator boost(Character player)
    {
        player.speedForce += speedBoost;
        player.jumpForce += jumpBoost;
        yield return new WaitForSeconds(boostTime);
        player.speedForce -= speedBoost;
        player.jumpForce -= jumpBoost;
        Destroy(this.gameObject);
    }

    public void gainBoost(Character player)
    {
        if (player.tag != "Player") { return; }
        this.GetComponent<AudioSource>().Play();
        StartCoroutine(boost(player));
    }

}

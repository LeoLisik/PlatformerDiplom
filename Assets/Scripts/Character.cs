using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public bool isDead;
    public bool isGround;
    public float jumpForce = 300f;
    public float speedForce = 5f;

    public static event Action ActionButtonPressed;

    private int money = 0;
    private Rigidbody2D rigidbody2d;
    private Animator animator;  
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Settings.moveUp) && isGround && !isDead)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce));
            animator.SetBool("isJump", true);
            isGround = false;
        }
        if (Input.GetKey(Settings.moveRight) && !isDead)
        {
            rigidbody2d.velocity = new Vector2(speedForce, rigidbody2d.velocity.y);
            animator.SetBool("isMove", true);
        }
        if (Input.GetKey(Settings.moveLeft) && !isDead)
        {
            rigidbody2d.velocity = new Vector2(-speedForce, rigidbody2d.velocity.y);
            animator.SetBool("isMove", true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(Settings.use) && !isDead)
        {
            ActionButtonPressed?.Invoke();
        }
        if (!Input.GetKey(Settings.moveLeft) && !Input.GetKey(Settings.moveRight))
        {
            animator.SetBool("isMove", false);
        }
        if (Input.GetKeyDown(Settings.restart))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (rigidbody2d.velocity.x < 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 180;
            transform.rotation = rotation;
        }
        if (rigidbody2d.velocity.x > 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.y = 0;
            transform.rotation = rotation;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("isJump", false);
        }
        if (collision.gameObject.tag == "Eatable")
        {
            collision.gameObject.GetComponent<Fruit>().gainBoost(this);
            Destroy(collision.gameObject.GetComponent<Collider2D>());
            Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
        }
        if (collision.gameObject.tag == "Money")
        {
            money += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(dead());
        }
    }

    IEnumerator dead()
    {
        isDead = true;
        animator.SetBool("isDeath", true);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().dampTime = 2;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Respawn")
        {
            StartCoroutine(dead());
        }
        if (collision.gameObject.tag == "Tree")
        {
            ActionButtonPressed += collision.gameObject.GetComponent<Tree>().getFruit;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            ActionButtonPressed -= collision.gameObject.GetComponent<Tree>().getFruit;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" && Input.GetKeyUp(Settings.use))
        {
            if (money >= collision.gameObject.GetComponent<Bus>().payment)
            {
                collision.gameObject.GetComponent<Bus>().startExit();
                this.gameObject.SetActive(false);
            } //TODO: Текст если денег недостаточно
        }
    }
}

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

    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Settings.moveUp) && isGround && !isDead)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce));
            isGround = false;
        }
        if (Input.GetKey(Settings.moveRight) && !isDead)
        {
            rigidbody2d.velocity = new Vector2(speedForce, rigidbody2d.velocity.y);
        }
        if (Input.GetKey(Settings.moveLeft) && !isDead)
        {
            rigidbody2d.velocity = new Vector2(-speedForce, rigidbody2d.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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
        }
        if (collision.gameObject.tag == "Eatable")
        {
            collision.gameObject.GetComponent<Fruit>().gainBoost(this);
            Destroy(collision.gameObject.GetComponent<Collider2D>());
            Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
        }
    }

    IEnumerator dead()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Respawn")
        {
            isDead = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().dampTime = 2;
            StartCoroutine(dead());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree" && Input.GetKeyDown(Settings.use)) {
            (collision.gameObject.GetComponent<Tree>()).getFruit();
        }
        if (collision.gameObject.tag == "Finish" && Input.GetKeyUp(Settings.use))
        {
            collision.gameObject.GetComponent<Bus>().startExit();
            this.gameObject.SetActive(false);
        }
    }
}

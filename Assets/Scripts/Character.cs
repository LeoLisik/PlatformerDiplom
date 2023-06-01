using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGround && !isDead)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpForce));
            isGround = false;
        }
        if (Input.GetKey(KeyCode.D) && !isDead)
        {
            rigidbody2d.velocity = new Vector2(speedForce, rigidbody2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.A) && !isDead)
        {
            rigidbody2d.velocity = new Vector2(-speedForce, rigidbody2d.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            isDead = true;
            StartCoroutine(dead());
        }
    }

    IEnumerator dead()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

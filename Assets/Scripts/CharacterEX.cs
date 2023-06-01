using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEX : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
 
    public float move;
 
    // Use this for initialization
    void Start () {
 
    }
    
    // Update is called once per frame
    void FixedUpdate () {
 
 
        grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
 
        move = Input.GetAxis ("Horizontal");
 
    }
 
    void Update(){
        if (grounded && (Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {
 
            this.GetComponent<Rigidbody2D>().AddForce (new Vector2(0f,jumpForce));
        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        
        if (move > 0 && !facingRight)
            Flip ();
        else if (move < 0 && facingRight)
            Flip ();
 
 
 
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
 
        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
 
 
    }
    
    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

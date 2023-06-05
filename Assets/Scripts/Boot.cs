using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour
{
    public float repeatTime = 5f;
    public float jumpStrength = 1000f;

    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        InvokeRepeating("Jump", 0, repeatTime);
    }

    void Jump()
    {
        rigidbody2d.AddForce(new Vector2(0, jumpStrength));
    }
}
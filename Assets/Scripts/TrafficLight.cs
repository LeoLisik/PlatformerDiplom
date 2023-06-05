using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public float walkRange = 1f;
    public float moveSpeed = 0.007f;

    private bool isWalkRight = true;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWalkRight && transform.position.x >= startPos.x + walkRange)
        {
            isWalkRight = false;
        }
        if (isWalkRight && transform.position.x < startPos.x + walkRange)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        if (!isWalkRight && transform.position.x <= startPos.x - walkRange)
        {
            isWalkRight = true;
        }
        if (!isWalkRight && transform.position.x > startPos.x - walkRange)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
    }
}

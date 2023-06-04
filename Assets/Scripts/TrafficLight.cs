using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public float walkRange = 1f;

    private bool isWalkRight = true;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkRight && transform.position.x >= startPos.x + walkRange)
        {
            isWalkRight = false;
        }
        if (isWalkRight && transform.position.x < startPos.x + walkRange)
        {
            transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y);
        }
        if (!isWalkRight && transform.position.x <= startPos.x - walkRange)
        {
            isWalkRight = true;
        }
        if (!isWalkRight && transform.position.x > startPos.x - walkRange)
        {
            transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear2 : MonoBehaviour
{
    
    public float speed = 5f; 
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb; // Declare the Rigidbody2D variable

    void Start()
    {
        
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Assign the Rigidbody2D component
    }

    void Update()
    {
        {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x -= speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x += speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y -= speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y += speed * Time.deltaTime;
        }

        Vector2 newPos = new Vector2(x, y);
        gameObject.transform.position = newPos;
    }
    }
}
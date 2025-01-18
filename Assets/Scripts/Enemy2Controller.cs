using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2D;

    int directionx = -1;
    int directiony = -1;

    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        position.x = position.x + Time.deltaTime * speed * directionx;
        position.y = position.y + Time.deltaTime * speed * directiony;

        rigidbody2D.MovePosition(position);

        if (position.x < player.position.x)
        {
            directionx = 1; 
        }
        else
        {
            directionx = -1;
        }

        if (position.y < player.position.y)
        {
            directiony = 1; 
        }
        else
        {
            directiony = -1;
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.gameObject.name == "maincharacter")
        {
        //Debug.Log("YOU LOSE");
        }
    }
}

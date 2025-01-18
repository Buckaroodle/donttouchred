using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    //public float changeTime = 3.0f;
    //public bool vertical;

    Rigidbody2D rigidbody2D;
    //float timer;
    public bool startupward;
    public bool startrightward;
    int directionx = -1;
    int directiony = -1;
    AudioSource audioSource; 
    public AudioClip bounce;
    public PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //timer = changeTime;

        if (startupward)
        {
            directiony = 1;
        }

        if (startrightward)
        {
            directionx = 1;
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;

        /*if (timer < 0)
        {
            //direction = -direction;
            timer = changeTime;
        }
        */
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        /*
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        */

        position.x = position.x + Time.deltaTime * speed * directionx;
        position.y = position.y + Time.deltaTime * speed * directiony;
        
        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.gameObject.name == "maincharacter")
        {
        //Debug.Log("YOU LOSE");
        }

        if((other.transform.gameObject.name == "leftwall" || other.transform.gameObject.name == "rightwall") && playerController.isDead == false)
        {
        directionx = -directionx;
        PlaySound(bounce);
        }

        if((other.transform.gameObject.name == "topwall" || other.transform.gameObject.name == "bottomwall") && playerController.isDead == false)
        {
        directiony = -directiony;
        PlaySound(bounce);
        }

    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

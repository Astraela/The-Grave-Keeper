using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMover : MonoBehaviour
{
    Transform player;
    PlayerMovement playerMovement;
    public float speed;
    Rigidbody2D rb;
    public float walkRange = 2;
    Transform stang;
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.transform;
        rb = GetComponent<Rigidbody2D>();
        speed = playerMovement.speed;
        stang = transform.GetChild(0);
    }


    void Update()
    {
        float difference = transform.position.x - player.position.x;
        float movement = 0;
        if(Mathf.Abs(difference) > walkRange){
            movement = difference < 0 ? 1 : -1;
            movement = movement * speed;
            GetComponent<SpriteRenderer>().flipX = movement < 0;
            stang.transform.localPosition = new Vector3(1.77f * (movement < 0 ? -1 : 1),.61f,0);
        }
            rb.velocity = new Vector2(movement,0);
            GetComponent<Animator>().SetBool("Walking",movement != 0 );
    }
}

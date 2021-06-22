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
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.transform;
        rb = GetComponent<Rigidbody2D>();
        speed = playerMovement.speed;
        stang = transform.GetChild(0);
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        float difference = transform.position.x - player.position.x;
        float movement = 0;
        if(Mathf.Abs(difference) > walkRange){
            movement = difference < 0 ? 1 : -1;
            movement = movement * speed * Mathf.Max(1,(Mathf.Abs(difference)-walkRange));
            if(Mathf.Abs(difference) < walkRange * 1.2f){
                movement = Mathf.Clamp(movement, -walkRange,walkRange);
            }
            GetComponent<SpriteRenderer>().flipX = movement < 0;
            GetComponentInChildren<ShadowFlip>().Flip(movement < 0);
            stang.transform.localPosition = new Vector3(1.77f * (movement < 0 ? -1 : 1),.61f,0);
        }
        if(movement == 0){
            audioSource.Pause();
        }else{
            audioSource.UnPause();
        }
        // grounded = isGrounded();
        rb.velocity = new Vector2(movement,0);
            GetComponent<Animator>().SetBool("Walking",movement != 0 );
    }
}

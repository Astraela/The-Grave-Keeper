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
    public bool grounded = true;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.transform;
        rb = GetComponent<Rigidbody2D>();
        speed = playerMovement.speed;
        stang = transform.GetChild(0);
        audioSource = GetComponent<AudioSource>();
    }


    bool isGrounded(){
        Vector2 offset = new Vector3(1.5f,1.3f);
        var ray1 = Physics2D.Raycast(transform.position + new Vector3(offset.x,0,0), -Vector3.up,offset.y+.0f,LayerMask.GetMask("Default"));
        var ray2 = Physics2D.Raycast(transform.position - new Vector3(offset.x,0,0), -Vector3.up,offset.y+.0f,LayerMask.GetMask("Default"));
        Debug.DrawRay(transform.position - new Vector3(offset.x,0,0), -Vector3.up,Color.green, offset.y+.0f);
        if(Mathf.Abs(ray1.point.y - ray2.point.y) >=.1f)
            return true;
        return false;
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
        grounded = isGrounded();
        rb.velocity = new Vector2(movement,grounded?3:0);
            GetComponent<Animator>().SetBool("Walking",movement != 0 );
    }
}

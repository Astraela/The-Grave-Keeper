using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    Rigidbody2D rb;
    
    public float speed = 10;
    AudioSource audioSource;
    public bool grounded = true;
    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    bool isGrounded(){
        Vector2 offset = sr.bounds.size/2;
        offset.x = .2f;
        var ray1 = Physics2D.Raycast(transform.position + new Vector3(offset.x,0,0), -Vector3.up,offset.y+.0f,LayerMask.GetMask("Default"));
        var ray2 = Physics2D.Raycast(transform.position - new Vector3(offset.x,0,0), -Vector3.up,offset.y+.0f,LayerMask.GetMask("Default"));
        if(Mathf.Abs(ray1.point.y - ray2.point.y) >=.1f)
            return true;
        return false;
    }
    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        if(movement == 0){
            audioSource.Pause();
        } else{
            audioSource.UnPause();
        }
        if(!canMove){
            GetComponent<Animator>().SetBool("Walking",false);
            return;
        }
        movement = movement * speed;
        grounded = isGrounded();
        rb.velocity = new Vector2(movement,grounded?3:0);
        if(movement != 0){
            GetComponent<SpriteRenderer>().flipX = movement > 0;
            GetComponentInChildren<ShadowFlip>().Flip(movement < 0);
            audioSource.UnPause();
        }
            GetComponent<Animator>().SetBool("Walking",movement != 0);
        rb.isKinematic = movement == 0;
    }
}

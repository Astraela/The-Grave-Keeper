using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    Rigidbody2D rb;
    
    public float speed = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!canMove){
            GetComponent<Animator>().SetBool("Walking",false);
            return;
        }
        float movement = Input.GetAxisRaw("Horizontal");
        movement = movement * speed;
        rb.velocity = new Vector2(movement,0);
        if(movement != 0) GetComponent<SpriteRenderer>().flipX = movement > 0;
            GetComponent<Animator>().SetBool("Walking",movement != 0);
        
    }
}

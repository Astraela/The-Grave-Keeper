using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    public float speed = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!canMove)return;
        float movement = Input.GetAxisRaw("Horizontal");
        movement = movement * speed;
        rb.velocity = new Vector2(movement,0);

        
    }
}

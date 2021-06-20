using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarMover : MonoBehaviour
{
    Transform horse;
    HorseMover horseMover;
    float speed;
    Rigidbody2D rb;
    public float walkRange = 2;
    Transform stang;

    Dictionary<Transform,Vector3> offsets = new Dictionary<Transform, Vector3>();

    void Start()
    {
        horseMover = FindObjectOfType<HorseMover>();
        horse = horseMover.transform;
        rb = GetComponent<Rigidbody2D>();
        speed = FindObjectOfType<PlayerMovement>().speed;
        foreach(Transform child in transform){
            offsets.Add(child,child.localPosition);
        }
    }


    void Update()
    {
        Vector3 difference = transform.position - horse.position;
        float movement = 0;
        print(difference.magnitude);
        if(Mathf.Abs(difference.magnitude) > walkRange){
            movement = difference.x < 0 ? 1 : -1;
            movement = movement * speed;
            GetComponent<SpriteRenderer>().flipX = movement < 0;
            foreach(KeyValuePair<Transform,Vector3> child in offsets){
                child.Key.localPosition = new Vector3(child.Value.x * (movement < 0 ? -1 : 1), child.Value.y,0);
                if(child.Key.GetComponent<SpriteRenderer>()){
                    child.Key.GetComponent<SpriteRenderer>().flipX = movement <0;
                }
            }
        }
            rb.velocity = new Vector2(movement,0);
    }
}

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

    public float rotateSpeed = .1f;
    Transform wheel;
        AudioSource audioSource;
    public bool grounded = true;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        wheel = transform.GetChild(1);
        horseMover = FindObjectOfType<HorseMover>();
        horse = horseMover.transform;
        rb = GetComponent<Rigidbody2D>();
        speed = FindObjectOfType<PlayerMovement>().speed;
        foreach(Transform child in transform){
            offsets.Add(child,child.localPosition);
        }
        audioSource = GetComponent<AudioSource>();
    }

    bool isGrounded(){
        Vector2 offset = new Vector3(.9f,1.4f);
        var ray1 = Physics2D.Raycast(transform.position + new Vector3(offset.x,0,0), -Vector3.up,offset.y+.0f,LayerMask.GetMask("Default"));
        var ray2 = Physics2D.Raycast(transform.position - new Vector3(offset.x,0,0), -Vector3.up,offset.y+.0f,LayerMask.GetMask("Default"));
        Debug.DrawRay(transform.position - new Vector3(offset.x,0,0), -Vector3.up,Color.green, offset.y+.0f);
        if(Mathf.Abs(ray1.point.y - ray2.point.y) >=.1f)
            return true;
        return false;
    }

    void Update()
    {
        Vector3 difference = transform.position - horse.position;
        float movement = 0;
        if(difference.magnitude > walkRange){
            movement = difference.x < 0 ? 1 : -1;
            movement = movement * speed * Mathf.Max(1,(difference.magnitude-walkRange)*2f);
            if(difference.magnitude < walkRange * 1.2f){
                movement = Mathf.Clamp(movement, -walkRange,walkRange);
            }
            GetComponent<SpriteRenderer>().flipX = movement < 0;
            wheel.rotation *= Quaternion.Euler(0,0,rotateSpeed * difference.x < 0 ? -1 : 1);
            foreach(KeyValuePair<Transform,Vector3> child in offsets){
                if(child.Key.name == "DeadBody") continue;
                child.Key.localPosition = new Vector3(child.Value.x * (movement < 0 ? -1 : 1), child.Value.y,0);
                if(child.Key.GetComponent<SpriteRenderer>()){
                    child.Key.GetComponent<SpriteRenderer>().flipX = movement <0;
                    GetComponentInChildren<ShadowFlip>().Flip(movement > 0);
                }
            }
        }
        if(movement == 0){
            audioSource.Pause();
        }else{
            audioSource.UnPause();
        }
        grounded = isGrounded();
        rb.velocity = new Vector2(movement,grounded?3:0);
    }
}

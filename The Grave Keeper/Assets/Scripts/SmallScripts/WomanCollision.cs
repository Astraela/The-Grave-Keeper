using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col){
        Destroy(GetComponent<Rigidbody2D>());
    }
}

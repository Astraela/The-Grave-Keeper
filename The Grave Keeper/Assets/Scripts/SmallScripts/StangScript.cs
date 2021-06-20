using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StangScript : MonoBehaviour
{
    public Transform stang1;
    public Transform stang2;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = stang1.position - stang2.position;
        transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg);
        transform.position = Vector3.Lerp(stang1.position,stang2.position,.5f);
        transform.GetComponent<SpriteRenderer>().size = new Vector2(Mathf.Abs(dir.x),.1397f);
    }
}

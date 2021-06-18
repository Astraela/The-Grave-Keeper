using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningFade : MonoBehaviour
{
    Color c;
    public float step = .01f;
    void Start()
    {
        c = GetComponent<Image>().color;
        c.a = 1;
        GetComponent<Image>().color = c;
    }

    // Update is called once per frame
    void Update()
    {
        c.a -= step * Time.deltaTime;
        GetComponent<Image>().color = c;
        if(c.a <= 0){
            Destroy(gameObject);
        }
    }
}

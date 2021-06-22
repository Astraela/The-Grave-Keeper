using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningFade : AnimationComponent
{
    Color c;
    public float step = .01f;
    void Awake()
    {
        c = GetComponent<Image>().color;
        c.a = 1;
        GetComponent<Image>().color = c;
    }

    public override void Animate()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade(){
        print("Test");
        while(true){
            c.a -= step * Time.deltaTime;
            GetComponent<Image>().color = c;
            if(c.a <= 0){
                Destroy(gameObject);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}

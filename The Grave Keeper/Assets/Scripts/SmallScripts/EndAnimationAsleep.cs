using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndAnimationAsleep : AnimationComponent
{
    public Image fade;
    public override void Animate()
    {
        StartCoroutine("Lights");
    }

    IEnumerator Lights(){
        while(true){
            yield return new WaitForEndOfFrame();
            Color color = fade.color;
            color.a += 1/255f;
            fade.color = color;
            if(color.a >= 1){
                SceneManager.LoadScene(5);
            }
        }
    }
}

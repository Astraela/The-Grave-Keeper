using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndAnimation : AnimationComponent
{
    public Light2D globalLight;
    public Light2D playerSpotlight;
    public Light2D wifeSpotlight;
    public Image fade;
    public override void Animate()
    {
        StartCoroutine("Lights");
    }

    IEnumerator Lights(){
        while(true){
            yield return new WaitForEndOfFrame();
            if(globalLight.intensity >= 0){
                globalLight.intensity -= 0.002f;
            }else{
                if(playerSpotlight.intensity <= 1f){
                    playerSpotlight.intensity += 0.001f;
                    wifeSpotlight.intensity += 0.001f;
                }else{
                    Color color = fade.color;
                    color.a += 1/255f;
                    fade.color = color;
                    if(color.a >= 1){
                        SceneManager.LoadScene(5);
                    }
                }
            }
        }
    }
}

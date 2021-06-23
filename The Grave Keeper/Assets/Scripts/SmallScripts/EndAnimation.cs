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
    public Sprite spriteObject;
    public Light2D Freeform;
    public Light2D pointlight;
    public override void Animate()
    {
        StartCoroutine("Lights");
        Destroy(transform.GetChild(1));
        Destroy(GetComponent<Animator>());
    }

    IEnumerator Lights(){
        while(true){
            FindObjectOfType<PlayerMovement>().canMove = false;
            yield return new WaitForEndOfFrame();
            if(globalLight.intensity >= 0 || Freeform.intensity >= 0 || pointlight.intensity >= 0){
                globalLight.intensity -= 0.002f;
                Freeform.intensity -= 0.002f;
                pointlight.intensity -= 0.004f;
            }else{
                if(playerSpotlight.intensity <= 1f){
                    playerSpotlight.intensity += 0.001f;
                    wifeSpotlight.intensity += 0.001f;
                    gameObject.GetComponent<SpriteRenderer>().sprite = spriteObject;
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

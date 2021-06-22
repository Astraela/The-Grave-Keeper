using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseIncreaser : MonoBehaviour
{
    float speedMultiplier = 1.0005f;
    IEnumerator Start(){
        StartCoroutine(Multiplier());
        Animator anim = GetComponent<Animator>();
        while(true){
            anim.SetFloat("runMultiplier", anim.GetFloat("runMultiplier")*speedMultiplier);
            yield return new WaitForEndOfFrame();
            print(speedMultiplier);
        }
    }

    IEnumerator Multiplier(){
        while(true){
            speedMultiplier -= 0.0000001f;
            for(int i = 1; i < 5; i++){
                yield return new WaitForEndOfFrame();
            }
            if(speedMultiplier <= 1){
                Destroy(this);
            }
        }
    }
}

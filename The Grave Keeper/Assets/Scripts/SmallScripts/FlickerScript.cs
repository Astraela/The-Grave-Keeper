using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickerScript : MonoBehaviour
{
    Light2D source;
    public float off = 0;
    public float on = .8f;
    public string pattern = "mmamammmmammamamaaamammma";
    public float incrementInSeconds = .2f;
    IEnumerator Start()
    {
        source = GetComponent<Light2D>();
        while(true){
            foreach(char c in pattern){
                float charnr = (char.ToUpper(c) - 'A')/26f;
                source.intensity = (on - off) * charnr + off;//(on - off) * (/26) + off;
                yield return new WaitForSeconds(incrementInSeconds);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseIncreaser : MonoBehaviour
{
    
    void Update()
    {
        GetComponent<Animator>().SetFloat("runMultiplier", GetComponent<Animator>().GetFloat("runMultiplier")*1.0005f);
    }
}

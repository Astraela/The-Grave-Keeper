using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFlip : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    
    public void Flip(bool right){
        if(right){
            Right.SetActive(true);
            Left.SetActive(false);
        }else{
            Right.SetActive(false);
            Left.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPointerScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public float addDistance;
    public GameObject pointerLeft;
    public GameObject pointerRight;

    private void Update(){
        if(targetPosition.x < transform.position.x-addDistance){
            pointerLeft.SetActive(true);
            pointerRight.SetActive(false);
        }else if(targetPosition.x > transform.position.x+addDistance){
            pointerLeft.SetActive(false);
            pointerRight.SetActive(true);
        }else{
            pointerLeft.SetActive(false);
            pointerRight.SetActive(false);
        }
        //else if(targetPosition.x > transform.position.x-addDistance && targetPosition.x < transform.position.x+addDistance){
        //    pointerLeft.SetActive(false);
        //    pointerRight.SetActive(false);
        //    pointerFollow.SetActive(true);
        //    pointerFollow.transform.position = Camera.main.WorldToScreenPoint(targetPosition + new Vector3(0, 100, 0));
    }
}

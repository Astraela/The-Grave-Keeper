using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPointerScript : MonoBehaviour
{
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;

    private void Awake(){
        targetPosition = new Vector3(200, 45);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    private void Update(){
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
    }
}

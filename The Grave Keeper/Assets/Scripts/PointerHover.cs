using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerHover : MonoBehaviour
{
    public GameObject picker;
    
    void Start()
    {
        picker.SetActive(false);
    }

    public void OnHover(GameObject obj){
        picker.transform.position = obj.transform.position - new Vector3(obj.GetComponent<RectTransform>().rect.width/2,0,0) - new Vector3(picker.GetComponent<RectTransform>().rect.width/2,0,0);
        picker.SetActive(true);
    }

    public void OnExit(){
        picker.SetActive(false);
    }
}

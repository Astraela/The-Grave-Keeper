using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EzCopySCript : MonoBehaviour
{
    
    void Update()
    {
        Color c = GetComponent<Image>().color;
        c.a = transform.parent.GetComponent<Image>().color.a;
        GetComponent<Image>().color = c;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetHerFall : MonoBehaviour
{
    public GameObject fallPosition;
    public GameObject woman;
    public GameObject body;

    public void SpawnWoman(){
        body = Instantiate(woman, fallPosition.transform.position, Quaternion.identity);
        body.transform.parent = gameObject.transform.GetChild(0).transform;
        body.transform.name = "DeadBody";
    }
}

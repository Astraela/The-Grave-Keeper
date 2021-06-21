using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetHerFall : MonoBehaviour
{
    public GameObject fallPosition;
    public GameObject woman;

    void Start(){
        SpawnWoman();
    }


    public void SpawnWoman(){
        GameObject clone = Instantiate(woman, fallPosition.transform.position, Quaternion.identity);
        clone.transform.parent = gameObject.transform.GetChild(0).transform;
        clone.transform.name = "DeadBody";
    }
}

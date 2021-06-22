using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetHerFall : AnimationComponent
{
    public GameObject fallPosition;
    public GameObject woman;
    public GameObject body;

    public override void Animate(){
        Debug.Log("AnimationRun");
        body = Instantiate(woman, fallPosition.transform.position, Quaternion.identity);
        body.transform.parent = gameObject.transform.GetChild(0).transform;
        body.transform.name = "DeadBody";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    public string identifier = "SomethingUnique";
    public bool setbool = true;
    public string boolean = "";
    
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        DialogueHelper dialogueHelper = FindObjectOfType<DialogueHelper>();
                dialogueHelper.animators.Add(identifier,this); 
    }

    virtual public void Animate(){
        GetComponent<Animator>().SetBool(boolean,setbool);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    public bool show = true;
    public string characterName = "";

    public Vector3 offset = Vector3.zero;
    public Vector3 circleOffset;

    public string talkToNode = "";

    public bool interactable = false;
    public YarnProgram scriptToLoad;
    
    public bool autoInteract = false;
    public float interactRange = 2f;

    public void UpdateVisiblity(bool newShow){
        if(show == newShow) return;
         GetComponent<SpriteRenderer>().enabled = newShow;
        show = newShow;
    }

    IEnumerator Start () { 
        yield return new WaitForEndOfFrame();
        DialogueHelper[] dialogueHelpers = FindObjectsOfType<DialogueHelper>();
        foreach(DialogueHelper dialogueHelper in dialogueHelpers){
            if(dialogueHelper.transform.name == "ORIGINAL"){
                dialogueHelper.Npcs.Add(characterName,this); 
            }
        }
        GetComponent<SpriteRenderer>().enabled = show;
        if (scriptToLoad != null) {
            DialogueRunner[] dialogueRunners = FindObjectsOfType<Yarn.Unity.DialogueRunner>();
            foreach(DialogueRunner dialogueRunner in dialogueRunners){
                if(dialogueRunner.transform.parent.name == "ORIGINAL"){
                    dialogueRunner.Add(scriptToLoad);  
                }
            }
        }
    }
}

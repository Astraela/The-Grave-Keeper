using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerInteraction : MonoBehaviour
{

    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2;
    NPC currentNpc = null;
    void Update(){
        if(Input.GetKeyUp(interactionKey) && currentNpc != null){
            Interact();
        }
        GetClosest();
    }

    public void DialogueEnd(){
        Camera.main.GetComponent<CameraMovement>().switchState(CameraMovement.state.Follow);
        GetComponent<PlayerMovement>().canMove = true;
    }

    void Interact(){
        DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
        if(dialogueRunner.IsDialogueRunning) return;
        GetComponent<PlayerMovement>().canMove = false;
        Camera.main.GetComponent<CameraMovement>().setStatic(currentNpc.transform.position + currentNpc.offset);
        dialogueRunner.StartDialogue (currentNpc.talkToNode);
    }

    void GetClosest(){
        var npcs = FindObjectsOfType<NPC>();
        NPC closestNpc = null;
        float dis = 1000000;
        foreach(NPC npc in npcs){
            if(npc.interactable == true){
                float distance = Vector3.Distance(this.transform.position,npc.transform.position);
                if(distance <= interactionRange && distance < dis){
                    dis = Vector3.Distance(this.transform.position,npc.transform.position);
                    closestNpc = npc;
                }
            }
        }
        currentNpc = closestNpc;
    }

}
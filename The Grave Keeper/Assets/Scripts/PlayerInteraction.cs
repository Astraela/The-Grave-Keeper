using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject Circle;
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2;
    NPC currentNpc = null;
    DialogueRunner dialogueRunner;
    void Start(){
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    void Update(){
        GetClosest();
        if(currentNpc != null){
            Circle.SetActive(true);
            Circle.transform.position = currentNpc.transform.GetComponent<Renderer>().bounds.max + new Vector3(.5f,.7f);
        }else{
            Circle.SetActive(false);
        }
        if(dialogueRunner.IsDialogueRunning) return;
        if(Input.GetKeyUp(interactionKey) && currentNpc != null){
            Interact();
        }
        if(currentNpc != null && currentNpc.autoInteract && Vector3.Distance(currentNpc.transform.position,transform.position) <= currentNpc.interactRange){
            Interact();
        }
    }

    public void DialogueEnd(){
        Camera.main.GetComponent<CameraMovement>().switchState(CameraMovement.state.Follow);
        GetComponent<PlayerMovement>().canMove = true;
    }

    void Interact(){
            Circle.SetActive(false);
        GetComponent<PlayerMovement>().canMove = false;
        Camera.main.GetComponent<CameraMovement>().setStatic(currentNpc.transform.position + currentNpc.offset);
        dialogueRunner.StartDialogue (currentNpc.talkToNode);
    }

    void GetClosest(){
        var npcs = FindObjectsOfType<NPC>();
        NPC closestNpc = null;
        float dis = 1000000;
        foreach(NPC npc in npcs){
            if(npc.interactable && npc.show){
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
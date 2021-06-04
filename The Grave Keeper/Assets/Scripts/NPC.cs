using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    public string characterName = "";

    public Vector3 offset = Vector3.zero;

    public string talkToNode = "";

    public bool interactable = false;
    public YarnProgram scriptToLoad;
    // Start is called before the first frame update
    void Start () {
        if (scriptToLoad != null) {
            DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
            dialogueRunner.Add(scriptToLoad);                
        }
    }
}

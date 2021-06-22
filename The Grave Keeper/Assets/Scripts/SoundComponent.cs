using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundComponent : MonoBehaviour
{
    string identifier = "somethingUnique";

    IEnumerator Start(){
        yield return new WaitForEndOfFrame();
        DialogueHelper dialogueHelper = FindObjectOfType<DialogueHelper>();
                dialogueHelper.sounds.Add(identifier,this); 
    }

    public void Play(){
        GetComponent<AudioSource>().Play();
    }
}

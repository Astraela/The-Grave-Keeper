using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueHelper : MonoBehaviour
{
    // Start is called before the first frame update
    DialogueRunner dialogueRunner;
    PlayerInteraction playerInteraction;
    private HashSet<string> _visitedNodes = new HashSet<string>();
    public RectTransform dialogueText;
    void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();

        dialogueRunner.AddFunction("visited", 1, (Yarn.Value[] parameters) => {return Visited(parameters);});
    }
    
    bool Visited(Yarn.Value[] parameters)
    {
        var nodeName = parameters[0];
        return _visitedNodes.Contains(nodeName.AsString);
    }

    public void NodeComplete(string nodeName) {
        _visitedNodes.Add(nodeName);
    }

	public void NodeStart(string nodeName) {

        var tags = new List<string>(dialogueRunner.GetTagsForNode(nodeName));
        
		Debug.Log($"Starting the execution of node {nodeName} with {tags.Count} tags.");
	}

    public void DialogueCompleted(){
        playerInteraction.DialogueEnd();
    }
    public void OptionsShow(){
        dialogueText.offsetMax = new Vector2(-553.79f,dialogueText.offsetMax.y);
    }
    public void OptionsHide(){
        dialogueText.offsetMax = new Vector2(-2.129882f,dialogueText.offsetMax.y);
    }
}

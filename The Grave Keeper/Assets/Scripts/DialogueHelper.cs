using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class DialogueHelper : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string,NPC> Npcs =  new Dictionary<string, NPC>();
    DialogueRunner dialogueRunner;
    PlayerInteraction playerInteraction;
    private HashSet<string> _visitedNodes = new HashSet<string>();
    public RectTransform dialogueText;
    public GameObject OptionsHeader;
    public GameObject OptionsFooter;
    void Start()
    {
        if(FindObjectsOfType<DialogueHelper>().Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();

        dialogueRunner.AddFunction("visited", 1, (Yarn.Value[] parameters) => {return Visited(parameters);});
        dialogueRunner.AddFunction("hide",1,Hide);
        dialogueRunner.AddFunction("show",1,Show);
        dialogueRunner.AddFunction("uninteractable",1,UnInteractable);
        dialogueRunner.AddFunction("interactable",1,Interactable);
        dialogueRunner.AddFunction("scene",1,Scene);
        dialogueRunner.AddFunction("focus",1,ChangeFocus);
        dialogueRunner.AddFunction("target",1,Target);
    }
    
    bool Visited(Yarn.Value[] parameters)
    {
        var nodeName = parameters[0];
        return _visitedNodes.Contains(nodeName.AsString);
    }

    void Hide(Yarn.Value[] parameters){
        var name = parameters[0].AsString;
        Npcs[name].UpdateVisiblity(false);
    }

    void UnInteractable(Yarn.Value[] parameters){
        var name = parameters[0].AsString;
        Npcs[name].interactable = false;
    }
    void Interactable(Yarn.Value[] parameters){
        var name = parameters[0].AsString;
        Npcs[name].interactable = true;
    }

    void Show(Yarn.Value[] parameters){
        var name = parameters[0].AsString;
        Npcs[name].UpdateVisiblity(true);
    }

    void Scene(Yarn.Value[] parameters){
        int sceneInt = (int)parameters[0].AsNumber;
        SceneManager.LoadScene(sceneInt);
    }

    void ChangeFocus(Yarn.Value[] parameteres){
        string focus = parameteres[0].AsString;
        string[] sections = focus.Split(',');
        Vector3 pos = new Vector3(float.Parse(sections[0]),float.Parse(sections[1]),float.Parse(sections[2]));
        FindObjectOfType<CameraMovement>().setStatic(pos);
    }
    void Target(Yarn.Value[] parameteres){
        string focus = parameteres[0].AsString;
        string[] sections = focus.Split(',');
        Vector3 pos = new Vector3(float.Parse(sections[0]),float.Parse(sections[1]),float.Parse(sections[2]));
        FindObjectOfType<DirectionPointerScript>().targetPosition = pos;
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
        dialogueText.GetComponent<Text>().text = "";
        OptionsHeader.transform.parent.gameObject.SetActive(false);
    }

    public void OptionsShow(){
        OptionsFooter.SetActive(true);
        OptionsHeader.SetActive(true);
    }

    public void OptionsHide(){
        OptionsFooter.SetActive(false);
        OptionsHeader.SetActive(false);
    }
}

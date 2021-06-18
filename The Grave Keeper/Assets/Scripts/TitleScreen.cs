using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject picker;
    public int SceneToLoad = 1;
    
    void Start()
    {
        picker.SetActive(false);
    }


    void Update()
    {
        
    }

    public void OnHover(GameObject obj){
        picker.transform.position = obj.transform.position - new Vector3(obj.GetComponent<RectTransform>().rect.width/2,0,0) - new Vector3(picker.GetComponent<RectTransform>().rect.width/2,0,0);
        picker.SetActive(true);
    }

    public void OnExit(){
        picker.SetActive(false);
    }

    public void Exit(){
        Application.Quit();
    }

    public void Play(){
        SceneManager.LoadScene(SceneToLoad);
    }
}

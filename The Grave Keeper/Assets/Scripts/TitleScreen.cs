using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public GameObject picker;
    public int SceneToLoad = 1;
    public GameObject skull;

    void Start()
    {
        picker.SetActive(false);
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

    IEnumerator OnPlay(){
        skull.SetActive(true);
        float step = .001f;
        float i = 0;
        RectTransform rect = skull.GetComponent<RectTransform>();
        Vector3 posStart = rect.position;
        Vector3 rectStart = skull.transform.localScale;
        Vector3 posGoal = new Vector3(5639,-2328,0);
        Vector3 rectGoal = new Vector3(306,306,306);
        Color c = skull.GetComponent<Image>().color;
        while(true){
            rect.position = Vector3.Lerp(posStart,posGoal,i);
            skull.transform.localScale = Vector3.Lerp(rectStart,rectGoal,i);
            c.a = i*200f;
            skull.GetComponent<Image>().color = c;
            if(i>1)break;
            i+= step*Time.deltaTime;
            step+=step*.1f;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(SceneToLoad);
    }

    public void Play(){
        StartCoroutine(OnPlay());
    }
}

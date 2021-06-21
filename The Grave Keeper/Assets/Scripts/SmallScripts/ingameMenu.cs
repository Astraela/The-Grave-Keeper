using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameMenu : MonoBehaviour
{

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
            GetComponent<PointerHover>();
        }
    }

    public void Resume(){
        GetComponent<Canvas>().enabled = false;
    }

    public void BackToMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Exit(){
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSpawner : MonoBehaviour
{
    public GameObject Horse;
    Vector3 min;
    Vector3 max;
    float timerMin = .5f;
    float timerMax = 5;
    float timer = 5;
    float sizeMin = .05f;
    float sizeMax = .5f;
    void Start()
    {
        min = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
        max = Camera.main.ScreenToWorldPoint(new Vector3(1920,1080,0));
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            StartCoroutine(spawnHorse());
            timer = Random.Range(timerMin,timerMax);
        }
    }

    IEnumerator spawnHorse(){
        var newHorse = Instantiate(Horse);
        SpriteRenderer sr = newHorse.GetComponent<SpriteRenderer>();
        Color c = sr.color;
        Horse.transform.position = new Vector3(Random.Range(min.x,max.x),Random.Range(min.y,max.y),0);
        float size = Random.Range(sizeMin,sizeMax);
        Horse.transform.localScale = new Vector3(size,size,size);
        Horse.SetActive(true);
        while(c.a < 1){
            c.a += 1f/350f;
            sr.color = c;
            yield return new WaitForEndOfFrame();
        }
    }
}

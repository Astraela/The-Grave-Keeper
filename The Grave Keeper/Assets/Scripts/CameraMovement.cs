using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform plr;
    public float focusRange = 5;
    public Vector3 offset = new Vector3(0,4,-10);

    Vector3 staticGoal;

    public enum state{
        Follow,
        Static
    }
    state currentState = state.Follow;
    
    public void switchState(state newState){
        currentState = newState;
    }
    
    public void setStatic(Vector3 goal){
        staticGoal = goal + offset;
        switchState(state.Static);
    }

    void FollowUpdate(){
        Vector3 goal = new Vector3(plr.position.x,0,0);
        Vector3 newPos = new Vector3(transform.position.x, plr.position.y,plr.position.z);
        if(Mathf.Abs(transform.position.x - goal.x) > focusRange){
            newPos = plr.position;
            if(Mathf.Round(transform.position.x -goal.x) <= -focusRange){
                newPos = newPos - new Vector3(focusRange,0,0);
            }else if(Mathf.Round(transform.position.x -goal.x) >= focusRange){
                newPos = newPos + new Vector3(focusRange,0,0);
            }
            var step = ((newPos + offset) - transform.position)/5;
            transform.position = transform.position + step;
        }else{
            var step = ((newPos + offset) - transform.position)/20;
            transform.position = transform.position + step;
        }
    }

    void StaticUpdate(){
        if(transform.position != staticGoal){
            transform.position = transform.position + (staticGoal - transform.position)/10;
        }
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case state.Follow:
                FollowUpdate();
            break;
            case state.Static:
                StaticUpdate();
            break;
        }
        if(Input.GetKey(KeyCode.E)){
            setStatic(plr.transform.position + offset + new Vector3(-7,3,0));
        }
        if(Input.GetKey(KeyCode.Q)){
            setStatic(plr.transform.position + offset + new Vector3(15,-2,0));
        }
        if(Input.GetKey(KeyCode.R)){
            switchState(state.Follow);
        }
    }
}

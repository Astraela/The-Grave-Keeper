using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = new Vector2(19,5);

    void Start(){
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorImage;
    void Start()
    {
        Cursor.SetCursor(cursorImage, new Vector2(0.13f, 0.87f), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

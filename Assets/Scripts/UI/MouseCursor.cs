using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] private Vector2 _cursorOffset;
    [SerializeField] private Texture2D _cursor;
    private void Start()
    {
        Vector2 cursorOffset = new Vector2(_cursor.width/2 + _cursorOffset.x, _cursor.height/2 + _cursorOffset.y);
        Cursor.SetCursor(_cursor, cursorOffset, CursorMode.Auto);
    }
}

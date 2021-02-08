using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEvents
{

    public delegate void MouseCursorEnable(bool enabled);

    public static event MouseCursorEnable MouseCursorEnabled;

    public static void Invoke_OnMouseCursorEnable(bool enabled)
    {
        MouseCursorEnabled?.Invoke(enabled);
    }
    
}

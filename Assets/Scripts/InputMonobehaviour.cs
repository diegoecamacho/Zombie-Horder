using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMonoBehaviour : MonoBehaviour
{
    protected PlayerInputActions gameInput;

    protected void Awake()
    {
        gameInput = new PlayerInputActions();
    }

    protected void OnEnable()
    {
        gameInput.Enable();
    }

    protected void OnDisable()
    {
        gameInput.Disable();
    }
}

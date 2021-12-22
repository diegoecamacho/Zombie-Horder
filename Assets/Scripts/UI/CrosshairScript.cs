using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrosshairScript : InputMonoBehaviour
{
    public Vector2 CurrentAimPosition { get; private set; }

    public Vector2 mouseSensitivity;

    private Vector2 crosshairStartingPosition;
    private Vector2 currentLookDeltas;

    [SerializeField, Range(0, 1)]
    private float crosshairHorizontalPercentage = 0.25f;
    
    private float horizontalOffset;
    private float maxHorizontalDeltaConstraint;
    private float minHorizontalDeltaConstraint;

    [SerializeField, Range(0, 1)]
    private float crosshairVerticalPercentage = 0.25f;

    private float verticalOffset;
    private float maxVerticalDeltaConstraint;
    private float minVerticalDeltaConstraint;

    public bool inverted = false;

    private bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.CursorActive)
        {
            AppEvents.Invoke_OnMouseCursorEnable(false);
        }

        crosshairStartingPosition = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);

        horizontalOffset = (Screen.width * crosshairHorizontalPercentage) / 2.0f;
        minHorizontalDeltaConstraint = -(Screen.width / 2.0f) + horizontalOffset;
        maxHorizontalDeltaConstraint = (Screen.width / 2.0f) - horizontalOffset;

        verticalOffset = (Screen.height * crosshairVerticalPercentage) / 2.0f;
        minVerticalDeltaConstraint = -(Screen.height / 2.0f) + verticalOffset;
        maxVerticalDeltaConstraint = (Screen.height / 2.0f) - verticalOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float crosshairXPosition = crosshairStartingPosition.x + currentLookDeltas.x;
        float crosshairYPosition = inverted ? crosshairStartingPosition.y - currentLookDeltas.y : crosshairStartingPosition.y + currentLookDeltas.y;

        CurrentAimPosition = new Vector2(crosshairXPosition, crosshairYPosition);

        transform.position = CurrentAimPosition;
    }

    private void OnLook(InputAction.CallbackContext delta)
    {
        Vector2 mouseDelta = delta.ReadValue<Vector2>();

        currentLookDeltas.x += mouseDelta.x * mouseSensitivity.x;
        if(currentLookDeltas.x >= maxHorizontalDeltaConstraint || currentLookDeltas.x <= minHorizontalDeltaConstraint)
        {
            currentLookDeltas.x -= mouseDelta.x * mouseSensitivity.x;
        }

        currentLookDeltas.y += mouseDelta.y * mouseSensitivity.y;
        if(currentLookDeltas.y >= maxVerticalDeltaConstraint || currentLookDeltas.y <= minVerticalDeltaConstraint)
        {
            currentLookDeltas.y -= mouseDelta.y * mouseSensitivity.y;
        }
    }

    private new void OnEnable()
    {
        base.OnEnable();
        gameInput.PlayerActionMap.Look.performed += OnLook;
    }

    private new void OnDisable()
    {
        base.OnDisable();
    }
}

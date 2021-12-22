using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    public float rotationPower = 10.0f;
    public float horizontalDampening = 1.0f;

    private Transform followTargetTransform;
    private Vector2 previousMouseDelta = Vector2.zero;

    private void Awake()
    {
        followTargetTransform = followTarget.transform;
    }

    private void OnLook(InputValue delta)
    {
        Vector2 aimValue = delta.Get<Vector2>();

        Quaternion addedRotation = Quaternion.AngleAxis(Mathf.Lerp(previousMouseDelta.x, aimValue.x, 1.0f / horizontalDampening) * rotationPower, transform.up);

        followTargetTransform.rotation *= addedRotation;

        previousMouseDelta = aimValue;

        transform.rotation = Quaternion.Euler(0, followTargetTransform.rotation.eulerAngles.y, 0);

        followTargetTransform.localEulerAngles = Vector3.zero;
    }
}

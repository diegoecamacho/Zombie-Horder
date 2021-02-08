using Parent;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
   public class CameraScript : InputMonoBehaviour
   {
      [SerializeField] private float RotationPower = 10;
      [SerializeField] private float HorizontalDamping = 1;
      [SerializeField] private GameObject FollowTarget;

      private Transform FollowTargetTransform;
      private Vector2 PreviousMouseDelta = Vector2.zero;

      private new void Awake()
      {
         base.Awake();
         FollowTargetTransform = FollowTarget.transform;
      }
      
      private void OnLooked(InputAction.CallbackContext obj)
      {
         Vector2 aimValue = obj.ReadValue<Vector2>();

         Quaternion addedRotation = Quaternion.AngleAxis(
            Mathf.Lerp(PreviousMouseDelta.x, aimValue.x, 1f / HorizontalDamping) * RotationPower,
            transform.up);

         FollowTargetTransform.rotation *= addedRotation;

         PreviousMouseDelta = aimValue;
         
         transform.rotation = Quaternion.Euler(0, FollowTargetTransform.rotation.eulerAngles.y, 0);
         
         FollowTargetTransform.localEulerAngles = Vector3.zero;
      }
      
      private new void OnEnable()
      {
         base.OnEnable();
         GameInput.PlayerActionMap.Look.performed += OnLooked;
            
      }
      
      private new void OnDisable()
      {
         base.OnDisable();
         GameInput.PlayerActionMap.Look.performed -= OnLooked;
   
      }
      
         
   }
}
   
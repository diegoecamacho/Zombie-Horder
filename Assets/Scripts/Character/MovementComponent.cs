using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Character
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float WalkSpeed;
        [SerializeField] private float RunSpeed;
        [SerializeField] private float JumpForce;
        [SerializeField] private float MoveDirectionBuffer = 2f;

        //Components
        private PlayerController PlayerController;
        private Animator PlayerAnimator;
        private Rigidbody PlayerRigidbody;
        private NavMeshAgent PlayerNavMeshAgent;

        //References
        private Transform PlayerTransform;

        private Vector3 NextPositionCheck;

        private Vector2 InputVector = Vector2.zero;
        private Vector3 MoveDirection = Vector3.zero;
        
        //Animator Hashes
        private readonly int MovementXHash = Animator.StringToHash("MovementX");
        private readonly int MovementYHash = Animator.StringToHash("MovementY");
        private readonly int IsJumpingHash = Animator.StringToHash("IsJumping");
        private readonly int IsRunningHash = Animator.StringToHash("IsRunning");

        private void Awake()
        {
            PlayerTransform = transform;
            PlayerController = GetComponent<PlayerController>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerRigidbody = GetComponent<Rigidbody>();
            PlayerNavMeshAgent = GetComponent<NavMeshAgent>();
        }


        /// <summary>
        /// Get's notified when the player moves, called by the PlayerInput Component.
        /// </summary>
        /// <param name="value"></param>
        public void OnMovement(InputValue value)
        {
            InputVector = value.Get<Vector2>();
            
            PlayerAnimator.SetFloat(MovementXHash, InputVector.x);
            PlayerAnimator.SetFloat(MovementYHash, InputVector.y);
        }
        
        /// <summary>
        /// Get's notified when the player starts and ends running, Called by the PlayerInput component
        /// </summary>
        /// <param name="value"></param>
        public void OnRun(InputValue value)
        {
            Debug.Log(value.isPressed);
            PlayerController.IsRunning = value.isPressed;
            PlayerAnimator.SetBool(IsRunningHash, value.isPressed);
        }
        
        /// <summary>
        /// Get's notified when the player presses the jump key, Called by the PlayerInput component
        /// </summary>
        /// <param name="value"></param>
        public void OnJump(InputValue value)
        {
            if (PlayerController.IsJumping) return;
            
            PlayerController.IsJumping = value.isPressed;
            PlayerAnimator.SetBool(IsJumpingHash, value.isPressed);
            PlayerRigidbody.AddForce((PlayerTransform.up + MoveDirection) * JumpForce, ForceMode.Impulse);
        }

        private void Update()
        {
            if (PlayerController.IsJumping) return;

            MoveDirection = PlayerTransform.forward * InputVector.y + PlayerTransform.right * InputVector.x;

            float currentSpeed = PlayerController.IsRunning ? RunSpeed : WalkSpeed;

            Vector3 movementDirection = MoveDirection * (currentSpeed * Time.deltaTime);

            NextPositionCheck = transform.position + MoveDirection * MoveDirectionBuffer;
            if (NavMesh.SamplePosition(NextPositionCheck, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                transform.position += movementDirection;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.CompareTag("Ground") || !PlayerController.IsJumping) return;
            
            PlayerController.IsJumping = false;
            PlayerAnimator.SetBool(IsJumpingHash, false);
        }

        private void OnDrawGizmos()
        {
            if (NextPositionCheck != Vector3.zero)
            {
                Gizmos.DrawWireSphere(NextPositionCheck, 0.5f);
            }
        }
    }
}

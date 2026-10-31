using System;
using Animancer;
using Project.Script.RunTime.Data.Configs.CharacterConfig;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Utils;
using Project.Script.RunTime.Utils.Pojo;
using QFramework;
using UnityEngine;

namespace Project.Script.RunTime.Gameplay.Character
{
    public class CharacterControllerBase : MonoBehaviour
    {
        [SerializeField] public float speed = 2.5f;
        [SerializeField] public bool isRootMovement = false;
        [HideInInspector]public FSM<CharacterStateEnum> fsm;
        protected CharacterController characterController;
        protected Animator animator;
        protected Transform head;
        [HideInInspector]public AnimancerComponent animancer;
        [SerializeField, Range(0f, 1f)]
        private float lookWeight = 1f;
        public CharacterConfigBase characterConfig;
        public CharacterReusableDataBase reusableData;
        
        
        [Header("地面检测")] [Tooltip("检测球距离")] public float groundDetectedOffset = -0.06f;
        [Tooltip("检测球大小")] public float groundRadius = 0.2f;
        [Tooltip("检测的图层")] public LayerMask groundMask;
        
        public ValueBox<float> gravity = new ValueBox<float>(-12);
        private ValueBox<float> _verticalSpeed = new ValueBox<float>();
        private Vector3 _verticalVelocity;
        [Tooltip("下坠最高速度和上升最高速度")] public ValueBox<Vector2> velocityLimit = new ValueBox<Vector2>(new Vector2(-20, 60));
        public ValueBox<bool> isGrounded =  new ValueBox<bool>();
        
        public ValueBox<bool> isUpper =  new ValueBox<bool>();
        public bool isOnGravity;
        // [HideInInspector]
        protected virtual void Awake()
        {
            fsm = new FSM<CharacterStateEnum>();
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            animancer = GetComponent<AnimancerComponent>();
            head = animator.GetBoneTransform(HumanBodyBones.Head);
        }

        protected virtual void Start()
        {
            animancer.Graph.ApplyAnimatorIK = true;
            
            
            fsm.StartState(CharacterStateEnum.Idle);
        }


        protected virtual void Update()
        {
            fsm.Update();
            CheckOnGround();
            CharacterGravity();
        }
        
        protected virtual void OnAnimatorMove()
        {
            if (isRootMovement)
            {
                animator.ApplyBuiltinRootMotion();
                return;
            }
        }
        protected void OnAnimatorIK(int layerIndex)
        {
            if (head == null)
                return;

            Vector3 lookPosition =
                head.position + Camera.main.transform.forward * 10f;

            animator.SetLookAtWeight(
                lookWeight,
                0f,    // 身体参与程度
                1f,    // 头部参与程度
                0f,    // 眼球参与程度
                0.5f   // 限制注视范围
            );

            animator.SetLookAtPosition(lookPosition);
        }

        protected void UpdateCharacterMove(Vector3 moveDir, float magnification)
        {
            if (characterController.enabled)
            {
                characterController.Move(moveDir * magnification*speed*Time.deltaTime);
            }
            // Debug.Log(moveDir);
        }

        protected virtual void UpdateCharacterRotation(Quaternion deltaRotation)
        {
            if (isRootMovement) return;

            float yaw = deltaRotation.eulerAngles.y;
            if (Mathf.Approximately(yaw, 0f)) return;

            transform.rotation = Quaternion.Euler(0f, yaw, 0f) * transform.rotation;
        }
        
        private bool CheckOnGround()
        {
            Vector3 detectedOrigin = transform.position - groundDetectedOffset * Vector3.up;
            var hit = Physics.CheckSphere(detectedOrigin, groundRadius, groundMask, QueryTriggerInteraction.Ignore);
            isGrounded.Value = hit && _verticalSpeed.Value < 0;
            return isGrounded.Value;
        }
        private void CharacterGravity()
        {
            if (!isOnGravity || isRootMovement)
            {
                _verticalVelocity = Vector3.zero;
                return;
            }

            if (isGrounded.Value)
            {
                _verticalSpeed.Value = -2;
            }
            else
            {
                _verticalSpeed.Value += Time.deltaTime * gravity.Value;
                _verticalSpeed.Value = Mathf.Clamp(_verticalSpeed.Value, velocityLimit.Value.x, velocityLimit.Value.y);
            }

            _verticalVelocity = new Vector3(0, _verticalSpeed.Value, 0);
            if (characterController.enabled)
                characterController.Move(_verticalVelocity * Time.deltaTime);
        }
        
        public float ChangeVerticalSpeed(float verticalSpeed)
        {
            return this._verticalSpeed.Value = verticalSpeed;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = CheckOnGround() ? Color.green : Color.red;
            Gizmos.DrawWireSphere(transform.position - groundDetectedOffset * Vector3.up, groundRadius);
        }
    }
}
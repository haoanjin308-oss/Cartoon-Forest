using System;
using Animancer;
using Project.Script.RunTime.Data.Configs.CharacterConfig;
using Project.Script.RunTime.Data.Enums;
using QFramework;
using UnityEngine;

namespace Project.Script.RunTime.Gameplay.Character
{
    public class CharacterControllerBase : MonoBehaviour
    {
        [SerializeField] public float speed = 5f;
        [SerializeField] public bool isRootMovement = false;
        [HideInInspector]public FSM<CharacterStateEnum> fsm;
        protected CharacterController characterController;
        protected Animator animator;
        protected Transform head;
        [HideInInspector]public AnimancerComponent animancer;
        [SerializeField, Range(0f, 1f)]
        private float lookWeight = 1f;
        public CharacterConfigBase characterConfig;
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
        
    }
}
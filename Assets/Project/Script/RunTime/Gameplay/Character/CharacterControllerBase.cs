using System;
using Animancer;
using Project.Script.RunTime.Data.Enums;
using QFramework;
using UnityEngine;

namespace Project.Script.RunTime.Gameplay.Character
{
    public class CharacterControllerBase : MonoBehaviour
    {
        [SerializeField] public float speed = 5f;
        [SerializeField] public bool isRootMovement = false;
        protected FSM<CharacterStateEnum> fsm;
        public CharacterController characterController;
        public Animator animator;
        public AnimancerComponent animancerComponent;
        // [HideInInspector]
        protected virtual void Awake()
        {
            fsm = new FSM<CharacterStateEnum>();
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            animancerComponent = GetComponent<AnimancerComponent>();
        }

        protected virtual void Start()
        {
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

        protected void UpdateCharacterMove(Vector3 moveDir, Quaternion rot)
        {
            if (isRootMovement)
            {
                
            }

            if (characterController.enabled)
            {
                characterController.Move(moveDir);
            }
            Debug.Log(moveDir);
        }

        
    }
}
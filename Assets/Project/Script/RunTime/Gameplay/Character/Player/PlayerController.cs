using System;
using Project.Script.RunTime.Data.Configs.CharacterConfig.Player;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.Character.CharacterState;
using Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState;
using Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState.State;
using Project.Script.RunTime.Gameplay.PlayerInput;
using QFramework;
using UnityEngine;

namespace Project.Script.RunTime.Gameplay.Character.Player
{
    public class PlayerController : CharacterControllerBase
    {
        [HideInInspector]public PlayerInputSystem playerInputSystem;
        // public PlayerConfig playerConfig;
        
        
        protected override void Awake()
        {
            base.Awake();
            playerInputSystem = GetComponent<PlayerInputSystem>();
            
            fsm.AddState(CharacterStateEnum.Idle,new PlayerIdleState(this));
        }

        protected override void Start()
        {
            base.Start();
            fsm.StartState(CharacterStateEnum.Idle);
        }

        protected override void Update()
        {
            OnAnimatorMove();//加上动画记得取消
        }

        protected override void OnAnimatorMove()
        {
            base.OnAnimatorMove();
            Vector2 moveInput = playerInputSystem.Move;
            Vector3 moveDir = transform.forward * moveInput.y + transform.right * moveInput.x;
            moveDir = Vector3.ClampMagnitude(moveDir, 1f);
            float speedMul = playerInputSystem.Sprint ? 1.5f
                : playerInputSystem.Crouch ? 0.4f
                : 1f;
            UpdateCharacterMove(moveDir, speedMul);
            UpdateCharacterRotation(Quaternion.Euler(0f, playerInputSystem.Look.x, 0f));
        }

        protected override void UpdateCharacterRotation(Quaternion rotation)
        {
            // if(_playerInputSystem.Move != Vector2.zero)
                base.UpdateCharacterRotation(rotation);
        }
    }
}
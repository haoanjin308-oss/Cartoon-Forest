using System;
using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData.Data;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.Character.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState.State
{
    public class PlayerIdleState : PlayerStateBase
    {
        private readonly PlayerIdleData _idleData;
        public PlayerIdleState(PlayerController owner) : base(owner)
        {
            _idleData = playerConfig.PlayerAnimationData.PlayerIdleData;
        }

        protected override void OnEnter()
        {
            PlayAnimation(_idleData.Idle);
            base.OnEnter();
        }

        protected override void AddEvents()
        {
            base.AddEvents();
            playerInputSystem.playerInputMap.Player.Move.started += ChangeStateMove;
            playerInputSystem.playerInputMap.Player.Move.performed += ChangeStateMove;
        }

        protected override void RemoveEvents()
        {
            playerInputSystem.playerInputMap.Player.Move.started -= ChangeStateMove;
            playerInputSystem.playerInputMap.Player.Move.performed -= ChangeStateMove;
        }

        private void ChangeStateMove(InputAction.CallbackContext obj)
        {
            mFSM.ChangeState(CharacterStateEnum.Move);   
        }
    }
}
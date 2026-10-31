using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData.Data;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.Character.Player;
using UnityEngine.InputSystem;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState.State
{
    public class PlayerMoveState :PlayerStateBase
    {
        private PlayerMoveData _playerMoveData;
        public PlayerMoveState(PlayerController owner) : base(owner)
        {
            _playerMoveData = playerConfig.PlayerAnimationData.PlayerMoveData;
        }

        protected override void AddEvents()
        {
            base.AddEvents();
            playerInputSystem.playerInputMap.Player.Move.canceled += ChangeStateIdle;
        }

        private void ChangeStateIdle(InputAction.CallbackContext obj)
        {
            mFSM.ChangeState(CharacterStateEnum.Idle);
        }

        protected override void RemoveEvents()
        {
            base.RemoveEvents();
            playerInputSystem.playerInputMap.Player.Move.canceled -= ChangeStateIdle;
        }
    }
}
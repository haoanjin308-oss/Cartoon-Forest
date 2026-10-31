using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData.Data;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.Character.Player;
using UnityEngine;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState.State
{
    public class PlayerFallState : PlayerStateBase
    {
        private readonly PlayerFallData _playerFallData;

        public PlayerFallState(PlayerController owner) : base(owner)
        {
            _playerFallData = playerConfig.PlayerAnimationData.PlayerFallData;
        }

        protected override void OnEnter()
        {
            PlayAnimation(_playerFallData.Fall);
            base.OnEnter();
        }

        protected override void AddEvents()
        {
            base.AddEvents();
            // isGrounded.changeValue += ChangeStateIdle;
        }

        private void ChangeStateIdle(bool obj)
        {
            if (isGrounded.Value == true)
            {
                Debug.LogWarning(isGrounded.Value);
                mFSM.ChangeState(CharacterStateEnum.Idle);
            }
        }

        protected override void RemoveEvents()
        {
            base.RemoveEvents();
            // isGrounded.changeValue -= ChangeStateIdle;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (isGrounded.Value)
            {
                // PlayAnimation(
                //     heavy ? _playerFallData.FallEndMax : _playerFallData.FallEnd);
                // mOwner.SyncLanding(heavy);
                // AnimancerState.Events(this).OnEnd = () => 
                mFSM.ChangeState(CharacterStateEnum.Idle);
            }
        }
    }
}
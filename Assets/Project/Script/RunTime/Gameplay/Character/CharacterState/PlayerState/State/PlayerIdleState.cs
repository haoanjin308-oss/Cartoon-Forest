using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData.Data;
using Project.Script.RunTime.Gameplay.Character.Player;
using UnityEngine;

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
            base.OnEnter();
            PlayAnimation(_idleData.Idle);
            Debug.LogWarning(animancerState);
        }
    }
}
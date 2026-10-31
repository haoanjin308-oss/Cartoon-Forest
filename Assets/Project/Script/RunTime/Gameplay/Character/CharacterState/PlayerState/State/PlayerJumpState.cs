using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData.Data;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.Character.Player;
using Project.Script.RunTime.Utils;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState.State
{
    public class PlayerJumpState : PlayerStateBase
    {
        private readonly PlayerJumpData _playerJumpData;
        public PlayerJumpState(PlayerController owner) : base(owner)
        {
            _playerJumpData = playerConfig.PlayerAnimationData.PlayerJumpData;
        }

        protected override void OnEnter()
        {
            PlayAnimation(_playerJumpData.Jump);
            // animancerState.Events(this).OnEnd = () => mFSM.ChangeState(CharacterStateEnum.Fall);
            mOwner.ChangeVerticalSpeed(MathUtils.GetJumpInitVelocity(0.8f, mOwner.gravity.Value));
            base.OnEnter();
        }

        protected override void OnExit()
        {
            base.OnExit();
            
        }

        protected override void AddEvents()
        {
            base.AddEvents();
            animancerState.Events(this).OnEnd = () =>
            {
                if (mFSM.CurrentStateId == CharacterStateEnum.Jump)
                {
                    mFSM.ChangeState(CharacterStateEnum.Fall);
                }
            };
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (isGrounded.Value)
            {
                mFSM.ChangeState(CharacterStateEnum.Idle);
            }
        }
    }
}
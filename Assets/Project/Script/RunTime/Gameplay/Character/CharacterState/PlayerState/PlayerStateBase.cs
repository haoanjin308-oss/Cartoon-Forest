using Project.Script.RunTime.Data.Configs.CharacterConfig.Player;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.Character.Player;
using Project.Script.RunTime.Gameplay.PlayerInput;
using UnityEngine.InputSystem;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState
{
    public class PlayerStateBase : CharacterStateBase
    {
        protected PlayerController playerController;
        protected PlayerInputSystem playerInputSystem;
        protected PlayerReusableData playerReusableData;
        protected readonly PlayerConfig playerConfig;
        protected PlayerStateBase(PlayerController owner) : base(owner)
        {
            this.playerController = owner;
            playerInputSystem = owner.playerInputSystem;
            playerConfig = (PlayerConfig)owner.characterConfig;
            playerReusableData = (PlayerReusableData)owner.reusableData;
        }

        protected override void OnEnter()
        {
            base.OnEnter();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            UpdateSpeed();
            UpdateCrouch();
        }

        protected override void OnExit()
        {
            base.OnExit();
        }

        protected override void AddEvents()
        {
            base.AddEvents();
            playerInputSystem.playerInputMap.Player.Jump.started += ChangeStateJump;
            playerController.isGrounded.changeValue += ChangeStateFall;
        }

        

        protected override void RemoveEvents()
        {
            base.RemoveEvents();
            playerInputSystem.playerInputMap.Player.Jump.started -= ChangeStateJump;
            playerController.isGrounded.changeValue -= ChangeStateFall;
        }



        private void ChangeStateJump(InputAction.CallbackContext obj)
        {
            if(mFSM.CurrentStateId != CharacterStateEnum.Jump && mFSM.CurrentStateId != CharacterStateEnum.Fall && isGrounded.Value)
                mFSM.ChangeState(CharacterStateEnum.Jump);   
        }

        private void UpdateSpeed()
        {
            if (!playerInputSystem.IsCrouch)
                playerReusableData.SpeedValueParameter.TargetValue = playerInputSystem.IsSprint ? 2 : 1;
        }

        private void UpdateCrouch()
        {
            playerReusableData.CrouchValueParameter.TargetValue = playerInputSystem.IsCrouch ? 2 : 1;
        }
        
        private void ChangeStateFall(bool value)
        {
            if(mFSM.CurrentStateId != CharacterStateEnum.Jump && mFSM.CurrentStateId != CharacterStateEnum.Fall)
                if(!isGrounded.Value)
                    mFSM.ChangeState(CharacterStateEnum.Fall);
        }
    }
}
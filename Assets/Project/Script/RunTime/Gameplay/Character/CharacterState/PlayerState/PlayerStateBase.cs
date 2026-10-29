using Project.Script.RunTime.Data.Configs.CharacterConfig.Player;
using Project.Script.RunTime.Gameplay.Character.Player;
using Project.Script.RunTime.Gameplay.PlayerInput;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState
{
    public class PlayerStateBase : CharacterStateBase
    {
        protected PlayerController playerController;
        protected PlayerInputSystem playerInputSystem;
        protected readonly PlayerConfig playerConfig;
        protected PlayerStateBase(PlayerController owner) : base(owner)
        {
            this.playerController = owner;
            playerInputSystem = owner.playerInputSystem;
            playerConfig = (PlayerConfig)owner.characterConfig;
        }

        protected override void OnEnter()
        {
            base.OnEnter();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }

        protected override void OnExit()
        {
            base.OnExit();
        }
    }
}
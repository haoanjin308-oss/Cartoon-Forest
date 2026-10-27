using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState.Base;
using Project.Script.RunTime.Gameplay.Character.Player;
using QFramework;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState
{
    public class PlayerMoveState :PlayerStateBase
    {
        public PlayerMoveState(FSM<CharacterStateEnum> fsm, PlayerController owner) : base(fsm, owner)
        {
        }
    }
}
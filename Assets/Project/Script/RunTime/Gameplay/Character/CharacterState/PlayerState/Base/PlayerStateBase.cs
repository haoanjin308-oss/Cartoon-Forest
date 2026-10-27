using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.Character.Player;
using QFramework;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState.PlayerState.Base
{
    public class PlayerStateBase : CharacterStateBase
    {
        public PlayerStateBase(FSM<CharacterStateEnum> fsm, PlayerController owner) : base(fsm, owner)
        {
        }
    }
}
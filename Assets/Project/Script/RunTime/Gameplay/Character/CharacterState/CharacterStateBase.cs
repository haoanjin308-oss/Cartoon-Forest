using Project.Script.RunTime.Data.Enums;
using QFramework;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState
{
    public class CharacterStateBase : AbstractState<CharacterStateEnum,CharacterControllerBase>
    {
        public CharacterStateBase(FSM<CharacterStateEnum> fsm, CharacterControllerBase owner) : base(fsm, owner)
        {
            
        }
        
    }
}
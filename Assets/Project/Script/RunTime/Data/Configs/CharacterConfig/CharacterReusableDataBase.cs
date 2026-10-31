using Animancer;
using Project.Script.RunTime.Gameplay.Character;

namespace Project.Script.RunTime.Data.Configs.CharacterConfig
{
    public class CharacterReusableDataBase
    {
        public SmoothedFloatParameter SpeedValueParameter;
        public SmoothedFloatParameter CrouchValueParameter;

        protected CharacterReusableDataBase(CharacterControllerBase controller)
        {
            
        }
    }
}
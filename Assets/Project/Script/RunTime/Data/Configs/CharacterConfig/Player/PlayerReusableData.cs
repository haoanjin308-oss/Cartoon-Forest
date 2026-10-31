using Animancer;
using Project.Script.RunTime.Gameplay.Character;
using Project.Script.RunTime.Gameplay.Character.Player;

namespace Project.Script.RunTime.Data.Configs.CharacterConfig.Player
{
    public class PlayerReusableData : CharacterReusableDataBase
    {
        private readonly PlayerController _playerController;
        private readonly PlayerConfig _playerConfig;
        public PlayerReusableData(CharacterControllerBase controller) : base(controller)
        {
            _playerController = (PlayerController)controller;
            _playerConfig = (PlayerConfig)_playerController.characterConfig;
            SpeedValueParameter = new SmoothedFloatParameter(_playerController.animancer,_playerConfig.PlayerParameterData.SpeedValueParameter,0.2f);
            CrouchValueParameter = new SmoothedFloatParameter(_playerController.animancer,_playerConfig.PlayerParameterData.CrouchValueParameter,0.2f);
        }
    }
}
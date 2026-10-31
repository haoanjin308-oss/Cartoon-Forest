using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData;
using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.ParameterData;
using UnityEngine;

namespace Project.Script.RunTime.Data.Configs.CharacterConfig.Player
{
    [CreateAssetMenu(menuName = "Config/CharacterConfig/PlayerConfig")]
    public class PlayerConfig : CharacterConfigBase
    {
        [field: SerializeField] public PlayerAnimationData PlayerAnimationData { get; private set; }
        [field:SerializeField] public PlayerParameterData PlayerParameterData { get; private set; }
        
    }
}
using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData;
using UnityEngine;

namespace Project.Script.RunTime.Data.Configs.CharacterConfig.Player
{
    [CreateAssetMenu(menuName = "Config/CharacterConfig/PlayerConfig")]
    public class PlayerConfig : CharacterConfigBase
    {
        [field: SerializeField] public PlayerAnimationData PlayerAnimationData { get; private set; }
    }
}
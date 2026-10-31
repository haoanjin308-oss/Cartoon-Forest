using Animancer;
using UnityEngine;

namespace Project.Script.RunTime.Data.Configs.CharacterConfig.Player.ParameterData
{
    [System.Serializable]
    public class PlayerParameterData
    {
        [field:SerializeField] public StringAsset SpeedValueParameter { get; private set; }
        [field:SerializeField] public StringAsset CrouchValueParameter { get; private set; }
    }
}
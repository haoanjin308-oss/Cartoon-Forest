using Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData.Data;
using UnityEngine;

namespace Project.Script.RunTime.Data.Configs.CharacterConfig.Player.AnimationData
{
    [System.Serializable]
    public class PlayerAnimationData 
    {
        [field: SerializeField] public PlayerIdleData PlayerIdleData { get; private set; }
        [field: SerializeField] public PlayerMoveData PlayerMoveData { get; private set; }
        [field: SerializeField] public PlayerJumpData PlayerJumpData { get; private set; }
        [field: SerializeField] public PlayerFallData PlayerFallData { get; private set; }



    }
}
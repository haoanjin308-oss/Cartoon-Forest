using Animancer;
using Project.Script.RunTime.Data.Configs.CharacterConfig;
using Project.Script.RunTime.Data.Enums;
using QFramework;
using UnityEngine;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState
{
    public class CharacterStateBase : AbstractState<CharacterStateEnum,CharacterControllerBase>
    {
        protected AnimancerState animancerState;
        protected readonly AnimancerComponent animancer;
        protected CharacterConfigBase config;
        protected CharacterStateBase(CharacterControllerBase owner) : base(owner.fsm, owner)
        {
            animancer = owner.animancer;
            config = owner.characterConfig;
        }
        protected AnimancerState PlayAnimation(ITransition animancerTransition,float duration = 0.2f,FadeMode mode = FadeMode.FixedSpeed)
        {
            animancerState = animancer.Play(animancerTransition, duration, mode);
            Debug.LogError("yes");
            return animancerState;
        }
    }
}
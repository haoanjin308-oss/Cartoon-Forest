using Animancer;
using Project.Script.RunTime.Data.Configs.CharacterConfig;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Utils;
using Project.Script.RunTime.Utils.Pojo;
using QFramework;
using UnityEngine;

namespace Project.Script.RunTime.Gameplay.Character.CharacterState
{
    public class CharacterStateBase : AbstractState<CharacterStateEnum,CharacterControllerBase>
    {
        protected AnimancerState animancerState;
        protected readonly AnimancerComponent animancer;
        protected CharacterConfigBase config;
        protected ValueBox<bool> isUpper;
        protected ValueBox<bool> isGrounded;
        protected CharacterStateBase(CharacterControllerBase owner) : base(owner.fsm, owner)
        {
            animancer = owner.animancer;
            config = owner.characterConfig;
            isGrounded = owner.isGrounded;
            isUpper = owner.isUpper;
        }
        protected AnimancerState PlayAnimation(ITransition animancerTransition,float duration = 0.2f,FadeMode mode = FadeMode.FixedSpeed)
        {
            animancerState = animancer.Play(animancerTransition, duration, mode);
            return animancerState;
        }


        protected override void OnEnter()
        {
            base.OnEnter();
            Debug.Log(mFSM.CurrentState);
            AddEvents();
        }

        protected override void OnExit()
        {
            base.OnExit();
            RemoveEvents();

        }

        protected virtual void AddEvents()
        {
            
        }

        protected virtual void RemoveEvents()
        {

        }
    }
}
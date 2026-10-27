using System;
using Project.Script.RunTime.Data.Enums;
using Project.Script.RunTime.Gameplay.PlayerInput;
using QFramework;
using UnityEngine;

namespace Project.Script.RunTime.Gameplay.Character.Player
{
    public class PlayerController : CharacterControllerBase
    {
        private PlayerInputSystem _playerInputSystem;
        protected override void Awake()
        {
            base.Awake();
            _playerInputSystem = GetComponent<PlayerInputSystem>();
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            OnAnimatorMove();//加上动画记得取消
        }

        protected override void OnAnimatorMove()
        {
            base.OnAnimatorMove();
            Vector3 moveDir = new Vector3(_playerInputSystem.Move.x, 0, _playerInputSystem.Move.y);
            UpdateCharacterMove(moveDir*speed*Time.deltaTime,gameObject.transform.rotation);
        }
    }
}
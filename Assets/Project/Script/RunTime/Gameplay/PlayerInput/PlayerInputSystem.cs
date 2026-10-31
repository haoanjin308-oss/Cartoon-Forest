using UnityEngine;

namespace Project.Script.RunTime.Gameplay.PlayerInput
{
    public class PlayerInputSystem : MonoBehaviour
    {
        public PlayerInputMap playerInputMap;

        private void Awake()
        {
            playerInputMap = new PlayerInputMap();
        }

        private void OnEnable()
        {
            playerInputMap?.Enable();
        }

        private void OnDisable()
        {
            playerInputMap?.Disable();
        }

        public Vector2 Move
        {
            get
            {
                Vector2 moveDir = playerInputMap.Player.Move.ReadValue<Vector2>();
                moveDir.y = moveDir.y > 0 ? 1 : moveDir.y < 0 ? -1 : 0;
                moveDir.x = moveDir.x > 0 ? 1 : moveDir.x < 0 ? -1 : 0;
                return moveDir;
            }
        }
        public Vector2 Look => playerInputMap.Player.Look.ReadValue<Vector2>();

        public bool IsSprint => playerInputMap.Player.Sprint.IsPressed();
        public bool IsCrouch => playerInputMap.Player.Crouch.IsPressed();
    }
}
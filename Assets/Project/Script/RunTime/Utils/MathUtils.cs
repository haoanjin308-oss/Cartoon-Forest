using UnityEngine;

namespace Project.Script.RunTime.Utils
{
    public static class MathUtils
    {
        public static float GetJumpInitVelocity(float jumpMaxHeight, float gravity)
        {
            return Mathf.Sqrt(-2 * gravity * jumpMaxHeight);
        }
    }
}
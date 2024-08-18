using UnityEngine;

namespace GameEngine
{
    public sealed class MovementInput : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        public Vector2 GetDirection()
        {
            float horizontal = Input.GetAxis(HorizontalAxis);
            float vertical = Input.GetAxis(VerticalAxis);
            
            return new Vector2(horizontal, vertical);
        }
    }
}
using UnityEngine;

namespace GameEngine
{
    public sealed class MovementComponent : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5.0f;
        
        public void Move(Vector3 direction, float deltaTime)
        {
            transform.position += direction * (_speed * deltaTime);
        }
    }
}
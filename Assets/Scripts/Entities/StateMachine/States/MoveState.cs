using UnityEngine;

namespace Sample.Entities
{
    public sealed class MoveState : IState
    {
        private readonly Vector3 position;

        public MoveState(Vector3 position)
        {
            this.position = position;
        }

        public void Enter(GameObject entity)
        {
            
        }

        public void Update(GameObject entity, float deltaTime)
        {
            Debug.Log($"MOVE STATE {entity.name}");
        }

        public void Exit(GameObject entity)
        {
        }
    }
}
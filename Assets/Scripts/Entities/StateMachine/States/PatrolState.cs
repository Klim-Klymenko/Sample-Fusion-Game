using UnityEngine;

namespace Sample.Entities
{
    public sealed class PatrolState : IState
    {
        private readonly Vector3 position;
        
        public PatrolState(Vector3 position)
        {
            this.position = position;
        }

        public void Enter(GameObject entity)
        {
        }

        public void Update(GameObject entity, float deltaTime)
        {
            Debug.Log($"PATROL STATE {entity.name}");
        }

        public void Exit(GameObject entity)
        {
        }
    }
}
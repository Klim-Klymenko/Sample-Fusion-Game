using UnityEngine;

namespace Sample.Entities
{
    public sealed class AttackState : IState
    {
        public AttackState(GameObject targetGameObject)
        {
            
        }

        public void Enter(GameObject entity)
        {
        }

        public void Update(GameObject entity, float deltaTime)
        {
            Debug.Log($"ATTACK STATE {entity.name}");
        }

        public void Exit(GameObject entity)
        {
        }
    }
}
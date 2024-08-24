using UnityEngine;

namespace Sample.Entities
{
    public sealed class FollowState : IState
    {
        private readonly GameObject target;
        
        public FollowState(GameObject target)
        {
            this.target = target;
        }

        public void Enter(GameObject entity)
        {
        }

        public void Update(GameObject entity, float deltaTime)
        {
            Debug.Log($"FOLLOW STATE {entity.name}");
        }

        public void Exit(GameObject entity)
        {
        }
    }
}
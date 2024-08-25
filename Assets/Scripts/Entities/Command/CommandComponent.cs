using UnityEngine;

namespace Sample.Entities
{
    [RequireComponent(typeof(StateMachine))]
    public sealed class CommandComponent : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = this.GetComponent<StateMachine>();
        }

        public void Move(Vector3 position)
        {
            _stateMachine.ChangeState(new MoveState(position));
        }

        public void Follow(Transform target)
        {
            _stateMachine.ChangeState(new FollowState(target));
        }

        public void Patrol(Vector3 position)
        {
            _stateMachine.ChangeState(new PatrolState(position, this.transform.position));
        }

        public void Attack(GameObject target)
        {
            _stateMachine.ChangeState(new AttackState(target.gameObject));
        }

        public void Stop()
        {
            _stateMachine.DropState();
        }
    }
}
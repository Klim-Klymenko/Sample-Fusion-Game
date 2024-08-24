using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    [RequireComponent(typeof(StateMachine))]
    public sealed class NetworkStateMachineRunner : NetworkBehaviour
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = this.GetComponent<StateMachine>();
        }

        public override void FixedUpdateNetwork()
        {
            _stateMachine.Tick(this.Runner.DeltaTime);
        }
    }
}
using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    [RequireComponent(typeof(StateMachine))]
    public sealed class CommandComponent : NetworkBehaviour, ICommandComponent
    {
        private StateMachine _stateMachine;

        public override void Spawned()
        {
            _stateMachine = this.GetComponent<StateMachine>();
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
        }

        public void Move(Vector3 position)
        {
            if (this.Runner.IsClient)
            {
                this.RPC_Move(position);
            }
            else
            {
                _stateMachine.ChangeState(new MoveState(position));
            }
        }

        public void Follow(GameObject target)
        {
            if (this.Runner.IsClient)
            {
                this.RPC_Follow(target.GetComponent<NetworkObject>());
            }
            else
            {
                _stateMachine.ChangeState(new FollowState(target.transform));
            }
        }

        public void Patrol(Vector3 position)
        {
            this.RPC_Patrol(position);
        }

        public void Attack(GameObject target)
        {
            this.RPC_Attack(target.GetComponent<NetworkObject>());
        }

        public void Stop()
        {
            this.RPC_Stop();
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Move(Vector3 position) => _stateMachine.ChangeState(new MoveState(position));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Follow(NetworkObject target) => _stateMachine.ChangeState(new FollowState(target.transform));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Patrol(Vector3 position) => _stateMachine.ChangeState(new PatrolState(position));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Attack(NetworkObject target) => _stateMachine.ChangeState(new AttackState(target.gameObject));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable, InvokeLocal = false)]
        private void RPC_Stop() => _stateMachine.DropState();
    }
}
using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    [RequireComponent(typeof(StateMachine))]
    public sealed class CommandComponent : NetworkBehaviour, ICommandComponent
    {
        private StateMachine _stateMachine;
        private bool spawned;

        public override void Spawned()
        {
            _stateMachine = this.GetComponent<StateMachine>();
            this.spawned = true;
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            this.spawned = false;
        }

        public void Move(Vector3 position)
        {
            if (this.spawned)
            {
                this.RPC_Move(position);
            }
        }

        public void Patrol(Vector3 position)
        {
            if (this.spawned)
            {
                this.RPC_Patrol(position);
            }
        }

        public void Follow(GameObject target)
        {
            if (this.spawned)
            {
                this.RPC_Follow(target.GetComponent<NetworkObject>());
            }
        }

        public void Attack(GameObject target)
        {
            if (this.spawned)
            {
                this.RPC_Attack(target.GetComponent<NetworkObject>());
            }
        }

        public void Stop()
        {
            if (this.spawned)
            {
                this.RPC_Stop();
            }
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        public void RPC_Move(Vector3 position) => _stateMachine.ChangeState(new MoveState(position));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        public void RPC_Patrol(Vector3 position) => _stateMachine.ChangeState(new PatrolState(position));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        public void RPC_Follow(NetworkObject target) => _stateMachine.ChangeState(new FollowState(target.gameObject));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        public void RPC_Attack(NetworkObject target) => _stateMachine.ChangeState(new AttackState(target.gameObject));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        public void RPC_Stop() => _stateMachine.DropState();
    }
}
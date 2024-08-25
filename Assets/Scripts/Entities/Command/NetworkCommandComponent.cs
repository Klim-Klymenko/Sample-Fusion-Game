using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    [RequireComponent(typeof(StateMachine))]
    public sealed class NetworkCommandComponent : NetworkBehaviour, ICommandComponent
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = this.GetComponent<StateMachine>();
        }

        public void Move(Vector3 position) => this.RPC_Move(position);
        public void Patrol(Vector3 position) => this.RPC_Patrol(position);
        public void Follow(GameObject target) => this.RPC_Follow(target.GetComponent<NetworkObject>());
        public void Attack(GameObject target) => this.RPC_Attack(target.GetComponent<NetworkObject>());
        public void Stop() => this.RPC_Stop();

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_Move(Vector3 position) => _stateMachine.ChangeState(new MoveState(position));

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_Patrol(Vector3 position) => _stateMachine.ChangeState(new PatrolState(position));

        [ContextMenu("FOLLOW")]
        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        public void RPC_Follow(NetworkObject target) => _stateMachine.ChangeState(new FollowState(target.gameObject));

        [ContextMenu("ATTACK")]
        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        public void RPC_Attack(NetworkObject target) => _stateMachine.ChangeState(new AttackState(target.gameObject));

        [ContextMenu("STOP")]
        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        public void RPC_Stop() => _stateMachine.DropState();
    }
}
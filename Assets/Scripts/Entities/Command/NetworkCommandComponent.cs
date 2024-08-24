using ExitGames.Client.Photon.StructWrapping;
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
        public void Attack(GameObject target) => this.RPC_Attack(target.Get<NetworkObject>());
        public void Stop() => this.RPC_Stop();

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        private void RPC_Move(Vector3 position) => _stateMachine.ChangeState(new MoveState(position));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        private void RPC_Patrol(Vector3 position) => _stateMachine.ChangeState(new PatrolState(position));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        private void RPC_Follow(NetworkObject target) => _stateMachine.ChangeState(new FollowState(target.gameObject));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        private void RPC_Attack(NetworkObject target) => _stateMachine.ChangeState(new AttackState(target.gameObject));

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, Channel = RpcChannel.Reliable)]
        private void RPC_Stop() => _stateMachine.ResetState();
    }
}
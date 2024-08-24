using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    public sealed class RPCTest : NetworkBehaviour
    {
        [ContextMenu("TEST")]
        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        public void RPC_TEST()
        {
            Debug.Log("AAA");
        }
    }
}
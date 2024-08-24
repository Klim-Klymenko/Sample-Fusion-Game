using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Sample
{
    public sealed class PlayerJoinController : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {
        [SerializeField]
        private NetworkPrefabRef _playerPrefab;

        void IPlayerJoined.PlayerJoined(PlayerRef playerRef)
        {
            if (!this.Runner.IsServer)
            {
                return;
            }

            NetworkObject playerObject = this.Runner.Spawn(_playerPrefab, Vector3.zero, Quaternion.identity, playerRef);
            this.Runner.SetPlayerObject(playerRef, playerObject);
        }

        void IPlayerLeft.PlayerLeft(PlayerRef playerRef)
        {
            if (!this.Runner.IsServer)
            {
                return;
            }

            NetworkObject playerObject = this.Runner.GetPlayerObject(playerRef);
            if (playerObject != null)
            {
                this.Runner.Despawn(playerObject);
            }
        }
    }
}
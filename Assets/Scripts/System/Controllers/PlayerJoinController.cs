using Fusion;
using UnityEngine;

namespace Sample.System
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
            playerObject.name = playerRef.ToString();
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
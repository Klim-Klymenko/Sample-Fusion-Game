using System;
using Fusion;

namespace Sample.System
{
    public sealed class PlayerJoinController : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {
        private PlayerSpawner _playerSpawner;

        private void Awake()
        {
            _playerSpawner = this.GetComponent<PlayerSpawner>();
        }

        void IPlayerJoined.PlayerJoined(PlayerRef playerRef)
        {
            if (!this.Runner.IsServer)
            {
                return;
            }

            _playerSpawner.SpawnPlayer(playerRef);
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
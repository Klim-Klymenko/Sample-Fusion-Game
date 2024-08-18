using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Network
{
    public sealed class PlayerJoinManager : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {
        [SerializeField] 
        private NetworkPrefabRef _playerPrefab;

        [SerializeField] 
        private Vector3 _spawnPosition;

        [SerializeField]
        private Quaternion _spawnRotation;
        
        private readonly Dictionary<PlayerRef, NetworkObject> _players = new();
        
        void IPlayerJoined.PlayerJoined(PlayerRef playerRef)
        {
            if (!Runner.IsServer) return; 
            
            NetworkObject player = Runner.Spawn(_playerPrefab, _spawnPosition, _spawnRotation, playerRef);
            _players.Add(playerRef, player);
        }

        void IPlayerLeft.PlayerLeft(PlayerRef playerRef)
        {
            if (!Runner.IsServer) return;
            
            if (_players.Remove(playerRef, out NetworkObject player))
                Runner.Despawn(player);
        }
    }
}
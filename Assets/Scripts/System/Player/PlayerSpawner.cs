using Fusion;
using UnityEngine;

namespace Sample.System
{
    public sealed class PlayerSpawner : SimulationBehaviour
    {
        [SerializeField]
        private NetworkPrefabRef _playerPrefab;

        [SerializeField]
        private Bounds _spawnArea; 
        
        public void SpawnPlayer(PlayerRef playerRef)
        {
            Vector3 spawnPoint = this.RandomSpawnPoint();
            NetworkObject playerObject = this.Runner.Spawn(_playerPrefab, spawnPoint, Quaternion.identity, playerRef);
            this.Runner.SetPlayerObject(playerRef, playerObject);
        }

        private Vector3 RandomSpawnPoint()
        {
            return new Vector3(Random.Range(_spawnArea.min.x, _spawnArea.max.x), 0,
                Random.Range(_spawnArea.min.z, _spawnArea.max.z));
        }
    }
}
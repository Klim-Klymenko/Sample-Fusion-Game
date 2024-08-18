using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Archive.Network
{
    public sealed class FusionStartup : MonoBehaviour
    {
        [SerializeField] 
        private NetworkSceneManagerDefault _sceneManager;

        [SerializeField] 
        private NetworkRunner _runner;

        [SerializeField] 
        private string _sessionName = "SampleSession";

        private void Start()
        {
            StartSimulation(GameMode.AutoHostOrClient);
        }

        private async void StartSimulation(GameMode mode)
        {
            _runner.ProvideInput = true;
        
            await _runner.StartGame(new StartGameArgs
            {
                SessionName = _sessionName,
                SceneManager = _sceneManager,
                Scene = CreateScene(),
                GameMode = mode
            });
        }

        private SceneRef CreateScene()
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneRef sceneRef = SceneRef.FromIndex(buildIndex);

            if (sceneRef.IsValid)
                new NetworkSceneInfo().AddSceneRef(sceneRef, LoadSceneMode.Additive);

            return sceneRef;
        }
    }
}
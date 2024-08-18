using Fusion;
using GameEngine;
using UnityEngine;

namespace Network
{
    public sealed class NetworkInputPopulator : MonoBehaviour
    {
        [SerializeField] 
        private MovementInput _movementInput;

        [SerializeField]
        private NetworkCallbacksReceiver _callbacksReceiver;
        
        private void OnEnable()
        {
            _callbacksReceiver.OnPopulateInput += PopulateInput;     
        }

        private void OnDisable()
        {
            _callbacksReceiver.OnPopulateInput -= PopulateInput;     
        }

        private void PopulateInput(NetworkRunner runner, NetworkInput input)
        {
            NetworkInputData networkInputData = new()
            {
                MovementDirection = _movementInput.GetDirection()
            };

            input.Set(networkInputData);
        }
    }
}
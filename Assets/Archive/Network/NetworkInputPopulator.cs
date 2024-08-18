using Archive.GameEngine;
using Fusion;
using UnityEngine;

namespace Archive.Network
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

        private void PopulateInput(NetworkRunner _, NetworkInput input)
        {
            NetworkInputData networkInputData = new()
            {
                MovementDirection = _movementInput.GetDirection()
            };

            input.Set(networkInputData);
        }
    }
}
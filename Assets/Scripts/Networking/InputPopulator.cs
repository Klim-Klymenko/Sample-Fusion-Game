using Fusion;
using GameEngine;
using UnityEngine;

namespace Networking
{
    public sealed class InputPopulator : MonoBehaviour
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
            NetworkInputData inputData = new()
            {
                MovementInput = _movementInput.GetDirection()
            };

            input.Set(inputData);
        }
    }
}
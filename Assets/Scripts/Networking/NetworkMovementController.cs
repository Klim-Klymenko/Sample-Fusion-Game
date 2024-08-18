using Fusion;
using GameEngine;
using UnityEngine;

namespace Networking
{
    public sealed class NetworkMovementController : NetworkBehaviour
    {
        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField] 
        private NetworkInputReceiver _networkInputReceiver;
        
        public override void FixedUpdateNetwork()
        {
            _movementComponent.Move(_networkInputReceiver.MovementDirection, Runner.DeltaTime);
        }
    }
}
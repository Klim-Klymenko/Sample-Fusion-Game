using Fusion;
using GameEngine;
using UnityEngine;

namespace Archive.Network
{
    public sealed class NetworkMovementController : NetworkBehaviour
    {
        [SerializeField]
        private MovementComponent _movementComponent;
        
        public override void FixedUpdateNetwork()
        {
            if (!GetInput(out NetworkInputData inputData)) return;
            
            Vector2 movementInput = inputData.MovementDirection;
            Vector3 movementDirection = new Vector3(movementInput.x, 0, movementInput.y);
           
            _movementComponent.Move(movementDirection, Runner.DeltaTime);
        }
    }
}
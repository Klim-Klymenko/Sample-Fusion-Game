using Fusion;
using UnityEngine;

namespace Networking
{
    public sealed class NetworkInputReceiver : NetworkBehaviour
    {
        public Vector3 MovementDirection;

        public override void FixedUpdateNetwork()
        {
            if (!GetInput(out NetworkInputData inputData)) return;
           
            Vector2 movementInput = inputData.MovementInput;
            Vector3 movementDirection = new Vector3(movementInput.x, 0, movementInput.y);
            
            MovementDirection = movementDirection;
        }
    }
}
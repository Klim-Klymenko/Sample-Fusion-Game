using UnityEngine;

namespace Sample.Entities
{
    public sealed class StateMachine : MonoBehaviour
    {
        private IState _currentState;

        public void ChangeState(IState state)
        {
            // Debug.Log("CHANGE STATE");
            _currentState?.Exit(this.gameObject);
            _currentState = state;
            _currentState?.Enter(this.gameObject);
            // Debug.Log($"CURRENT STATE {_currentState!.GetType().Name}", this.gameObject);
        }

        public void RS()
        {
            // Debug.Log($"RESET STATE {_currentState?.GetType().Name}", this.gameObject);
            _currentState?.Exit(this.gameObject);
            _currentState = null;
        }

        public void Tick(float deltaTime)
        {
            // Debug.Log($"TICK STATE {_currentState?.GetType().Name}", this.gameObject);
            _currentState?.Update(this.gameObject, deltaTime);
        }
    }
}
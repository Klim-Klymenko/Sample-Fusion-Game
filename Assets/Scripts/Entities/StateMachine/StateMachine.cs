using Fusion;

namespace Sample.Entities
{
    public sealed class StateMachine : NetworkBehaviour
    {
        private IState _currentState;

        public void ChangeState(IState state)
        {
            _currentState?.Exit(this.gameObject);
            _currentState = state;
            _currentState?.Enter(this.gameObject);
        }

        public void DropState()
        {
            _currentState?.Exit(this.gameObject);
            _currentState = null;
        }

        public void Tick(float deltaTime)
        {
            _currentState?.Update(this.gameObject, deltaTime);
        }
    }
}
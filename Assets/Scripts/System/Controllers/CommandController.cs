using Sample.Entities;
using UnityEngine;

namespace Sample.System
{
    public sealed class CommandController : MonoBehaviour
    {
        private ClickInput _clickInput;
        private ICharacterProvider _characterProvider;

        private void Awake()
        {
            _clickInput = this.GetComponent<ClickInput>();
            _characterProvider = this.GetComponent<ICharacterProvider>();
        }
        
        private void OnEnable()
        {
            _clickInput.OnPointClicked += this.OnPointClicked;
            _clickInput.OnTargetClicked += this.OnTargetClicked;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _characterProvider.Character.GetComponent<ICommandComponent>().Stop();
            }
        }

        private void OnDisable()
        {
            _clickInput.OnPointClicked -= this.OnPointClicked;
            _clickInput.OnTargetClicked -= this.OnTargetClicked;
        }

        private void OnPointClicked(Vector3 point)
        {
            if (Input.GetKey(KeyCode.M))
            {
                _characterProvider.Character.GetComponent<ICommandComponent>().Move(point);
                return;
            }

            if (Input.GetKey(KeyCode.P))
            {
                _characterProvider.Character.GetComponent<ICommandComponent>().Patrol(point);
            }
        }

        private void OnTargetClicked(GameObject target)
        {
            if (target == _characterProvider.Character)
            {
                return;
            }

            if (Input.GetKey(KeyCode.F))
            {
                _characterProvider.Character.GetComponent<ICommandComponent>().Follow(target);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _characterProvider.Character.GetComponent<ICommandComponent>().Attack(target);
            }
        }
    }
}
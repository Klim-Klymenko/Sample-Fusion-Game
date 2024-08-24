using Fusion;
using UnityEngine;

namespace Sample
{
    public sealed class NetworkCommandComponent : NetworkBehaviour, ICommandComponent
    {
        public void Move(Vector3 position)
        {
            Debug.Log($"Move To Position {position}");
        }

        public void Patrol(Vector3 position)
        {
            Debug.Log($"Patrol To Position {position}");
        }

        public void Follow(GameObject target)
        {
            Debug.Log($"Follow target {target.name}");
        }

        public void Attack(GameObject target)
        {
            Debug.Log($"Attack target {target.name}");
        }

        public void Stop()
        {
            Debug.Log($"Stop!"); 
        }
    }
}


// _fsm.SwitchState(new MoveToPositionState(raycastHit.point));

//
//
// public void Update()
// {
//     if (Input.GetKey(KeyCode.M))
//     {
//         _fsm.SwitchState(new MoveToPositionState(raycastHit.point));
//     }
//     else if (Input.GetKey(KeyCode.P))
//     {
//         PatrolState state = _fsm.GetState<PatrolState>();
//         else
//         {
//             state = new PatrolState();
//             _fsm.SwitchState(state);
//             state.AddPatrolPoint(raycastHit.point);
//         }
//
//         //TODO: Патрулирование
//     }
//     else if (Input.GetKey(KeyCode.A))
//     {
//         if (raycastHit.transform.TryGetComponent(out IAtomicObject obj))
//         {
//             _fsm.SwitchState(new AttackState(obj));
//         }
//         //TODO: Атака цели
//     }
//     else if (Input.GetKey(KeyCode.F))
//     {
//         if (raycastHit.transform.TryGetComponent(out Transform transform))
//             _fsm.SwitchState(new FollowingState(transform));
//
//         //TODO: Преследование цели
//     }
//     else if (Input.GetKey(KeyCode.S))
//     {
//         _fsm.ResetState();
//
//         //TODO: Останока текущей команды
//     }
// }
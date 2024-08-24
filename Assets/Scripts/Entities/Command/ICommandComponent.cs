using UnityEngine;

namespace Sample.Entities
{
    public interface ICommandComponent
    {
        void Move(Vector3 position);
        void Patrol(Vector3 position);
        void Follow(GameObject target);
        void Attack(GameObject target);
        void Stop();
    }
}
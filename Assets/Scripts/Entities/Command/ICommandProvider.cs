using UnityEngine;

namespace Sample.Entities
{
    public interface ICommandProvider
    {
        void Move(Vector3 position);
        void Patrol(Vector3 position);
        void Follow(Transform target);
        void Attack(GameObject target);
        void Stop();
    }
}
using UnityEngine;

namespace Sample.Entities
{
    public sealed class StoppingDistanceComponent : MonoBehaviour
    {
        public float StoppingDistance
        {
            get { return this.stoppingDistance; }
        }

        public float StoppingDistanceSqr
        {
            get { return this.stoppingDistance * this.stoppingDistance; }
        }

        [SerializeField]
        private float stoppingDistance;
    }
}
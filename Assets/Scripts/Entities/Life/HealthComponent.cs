using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    public sealed class HealthComponent : NetworkBehaviour
    {
        [Networked]
        public int Health { get; set; }

        [SerializeField]
        private int maxHealth = 10;

        public override void Spawned()
        {
            this.Health = this.maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (this.Health > 0)
            {
                this.Health = Mathf.Max(0, Health - damage);
                if (this.Health <= 0)
                {
                    this.gameObject.GetComponent<DeathComponent>().Death();
                }
            }
        }
    }
}
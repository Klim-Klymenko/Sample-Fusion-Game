using Fusion;
using UnityEngine;

namespace Sample.Entities
{
    public sealed class ColoringComponent : NetworkBehaviour
    {
        [SerializeField]
        private MeshRenderer _renderer;
        
        public override void Spawned()
        {
            _renderer.material.color = this.HasInputAuthority ? Color.blue : Color.red;
        }
    }
}
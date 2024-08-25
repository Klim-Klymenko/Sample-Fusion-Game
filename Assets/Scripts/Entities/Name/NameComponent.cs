using Fusion;

namespace Entities
{
    public sealed class NameComponent : NetworkBehaviour
    {
        public override void Spawned()
        {
            this.gameObject.name = this.Object.InputAuthority.ToString();
        }
    }
}
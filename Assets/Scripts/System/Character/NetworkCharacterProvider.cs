using Fusion;
using UnityEngine;

namespace Sample.System
{
    public sealed class NetworkCharacterProvider : SimulationBehaviour, ICharacterProvider
    {
        public GameObject Character
        {
            get
            {
                PlayerRef myPlayer = this.Runner.LocalPlayer;
                NetworkObject character = this.Runner.GetPlayerObject(myPlayer);
                return character.gameObject;
            }
        }
    }
}
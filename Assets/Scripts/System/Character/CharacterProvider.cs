using Fusion;
using UnityEngine;

namespace Sample.System
{
    public sealed class CharacterProvider : SimulationBehaviour, ICharacterProvider
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
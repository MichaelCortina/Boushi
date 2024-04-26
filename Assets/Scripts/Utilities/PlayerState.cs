using UnityEngine;

namespace Utilities
{
    public class PlayerState : ScriptableObject
    {
        public const string PlayerName = "Player 1";
        [SerializeField] private int spawnPoint;
        
        public int SpawnPoint => spawnPoint;
    }
}

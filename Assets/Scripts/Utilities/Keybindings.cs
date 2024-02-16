using UnityEngine;
namespace Utilities
{
    public class Keybindings : MonoBehaviour
    {
        [SerializeField] private KeyCode interact = KeyCode.E;

        public KeyCode InteractKey => interact;

        private void Awake()
        {
            _instance = this;
        }

        private static Keybindings _instance;
        public static Keybindings Instance => _instance;
    }
}
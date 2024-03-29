using UnityEngine;
namespace Utilities
{
    public class Keybindings : MonoBehaviour
    {
        [SerializeField] private KeyCode interact = KeyCode.E;

        public static KeyCode InteractKey => _instance.interact;

        private void Awake()
        {
            _instance = this;
        }

        private static Keybindings _instance;
    }
}
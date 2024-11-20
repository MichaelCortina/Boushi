using UnityEngine;
namespace Utilities
{
    public class Keybindings : MonoBehaviour
    {
        [SerializeField] private KeyCode interact = KeyCode.E;
        [SerializeField] private KeyCode resetHat = KeyCode.R;

        public static KeyCode InteractKey => _instance.interact;
        public static KeyCode ResetKey => _instance.resetHat;

        private void Awake()
        {
            _instance = this;
        }

        private static Keybindings _instance;
    }
}
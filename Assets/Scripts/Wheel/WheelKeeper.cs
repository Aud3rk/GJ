using DefaultNamespace;
using Resources.Scripts;
using UnityEngine;

namespace Wheel
{
    public class WheelKeeper : MonoBehaviour, IInterctable
    {
        [SerializeField] private Transform cameraPos;
        private InputManager _inputManager;

        public void Start()
        {
            _inputManager = InputManager.Instance;
        }

        public void Interact(GameObject gameObject)
        {
            cameraPos.gameObject.SetActive(true);
            PlayerController.Instance.gameObject.SetActive(false);
            this.gameObject.GetComponent<WheelController>().enabled = true;
            this.gameObject.GetComponent<WheelController>().InputManager = _inputManager;
        }

        public void EndInteract()
        {
            cameraPos.gameObject.SetActive(false);
            PlayerController.Instance.gameObject.SetActive(true);
            this.gameObject.GetComponent<WheelController>().enabled = false;
        }
    }
}
using DefaultNamespace;
using Resources.Scripts;
using UnityEngine;

namespace Wheel
{
    public class WheelKeeper : MonoBehaviour, IInterctable
    {
        [SerializeField] private Transform cameraPos;
        private InputManager _inputManager;
        [SerializeField] private GameObject playerController;

        public void Start()
        {
            _inputManager = InputManager.Instance;
        }

        public void Interact(GameObject gameObject)
        {
            cameraPos.gameObject.SetActive(true);
            playerController.SetActive(false);
            this.gameObject.GetComponent<WheelController>().enabled = true;
            this.gameObject.GetComponent<WheelController>().InputManager = _inputManager;
        }

        public void EndInteract()
        {
            cameraPos.gameObject.SetActive(false);
            playerController.SetActive(true);
            this.gameObject.GetComponent<WheelController>().enabled = false;
        }
    }
}
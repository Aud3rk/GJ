using DefaultNamespace;
using Resources.Scripts;
using UnityEngine;
using Wheel;

namespace Cube
{
    public class CubeKeeper : MonoBehaviour, IInterctable
    {
        [SerializeField] private GameObject playerController;
        [SerializeField] private Transform cameraPos;
        private InputManager _inputManager;

        public void Start()
        {
            _inputManager = InputManager.Instance;
        }

        public void Interact(GameObject gameObject)
        {
            cameraPos.gameObject.SetActive(true);
            playerController.SetActive(false);
            this.gameObject.GetComponent<CubeController>().enabled = true;
            this.gameObject.GetComponent<CubeController>().InputManager = _inputManager;
        }

        public void EndInteract()
        {
            cameraPos.gameObject.SetActive(false);
            playerController.SetActive(true);
            this.gameObject.GetComponent<CubeController>().enabled = false;
        }
    }
}
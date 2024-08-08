using DefaultNamespace;
using Resources.Scripts;
using UnityEngine;

namespace KeyElements
{
    public class ClockRoom2 : MonoBehaviour, IInscriptionaleObject, IInterctable
    {
        private string _inscription = "А в это время в Англии пьют чай";
        private GameObject cameraPos;
        private GameObject playerController;
        private InputManager _inputManager;

        string IInscriptionaleObject.Inscription
        {
            get => _inscription;
            set => _inscription = value;
        }

        private void Awake()
        {
            _inputManager = InputManager.Instance;
        }

        public void Interact(GameObject gameObject)
        {
            cameraPos.gameObject.SetActive(true);
            playerController.SetActive(false);
            this.gameObject.GetComponent<ClockController>().enabled = true;
            this.gameObject.GetComponent<ClockController>().InputManager = _inputManager;
        }

        public void EndInteract()
        {
            
        }
    }
}
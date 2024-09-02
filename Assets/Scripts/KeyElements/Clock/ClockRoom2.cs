using Cube;
using DefaultNamespace;
using DG.Tweening;
using Resources.Scripts;
using UnityEngine;

namespace KeyElements
{
    public class ClockRoom2 : MonoBehaviour, IInscriptionaleObject, IInterctable
    {
        private string _inscription = "";
        public GameObject cameraPos;
        public GameObject playerController;
        private InputManager _inputManager;

        string IInscriptionaleObject.Inscription
        {
            get => _inscription;
            set => _inscription = value;
        }

        private void Start()
        {
            _inputManager = InputManager.Instance;
        }

        public void Interact(GameObject gameObject)
        {
            cameraPos.gameObject.SetActive(true);
            playerController.SetActive(false);
            this.gameObject.GetComponent<ClockController>().enabled = true;
            //this.gameObject.GetComponent<ClockController>().SecondArrow.GetComponent<ArrowController>().enabled = true;
            
            this.gameObject.GetComponent<ClockController>().InputManager = _inputManager;
        }

        public void EndInteract()
        {
            cameraPos.gameObject.SetActive(false);
            playerController.SetActive(true);
            gameObject.GetComponent<ClockController>().enabled = false;
        }
    }
}
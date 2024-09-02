using System;
using DefaultNamespace;
using UI;
using UnityEngine;

namespace Resources.Scripts
{
    public class InteractManager:MonoBehaviour
    {
        [SerializeField] private float pickUpRange = 1.5f;
        private InputManager _inputManager;
        private UIManager _uiManager;


        private void Start()
        {
            _inputManager = InputManager.Instance;
            _uiManager = UIManager.Instance;
        }

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                    pickUpRange))
            {
                if (_inputManager.PlayerPickUp())
                {
                    var hitedObject = hit.transform.GetComponent<IInterctable>();
                    if (hitedObject != null)
                    {
                        hitedObject.Interact(gameObject);
                    }
                }
                var inscriptionaleObject = hit.transform.GetComponent<IInscriptionaleObject>();
                if (inscriptionaleObject != null)
                {
                    _uiManager.Inscription.text = inscriptionaleObject.Inscription;
                }
                else _uiManager.Inscription.text = "";
            }
            else _uiManager.Inscription.text = "";
            
            
        }
    }
}
using DefaultNamespace;
using DG.Tweening;
using Resources.Scripts;
using UnityEngine;

namespace Events
{
    public class MugController : MonoBehaviour, IInterctable, IInscriptionaleObject
    {
        private string _inscription = "похоже, эта кружка напоминает мне о прошлом";

        public GameObject player;
        public Transform holdPos;
    
        public float pickUpRange = 5f; 
        private float rotationSensitivity = 1f;
        private Transform MugPos;
        private GameObject heldObj;
        private Rigidbody heldObjRb;
        private int LayerNumber;
        
        public void Interact(GameObject gameObject)
        {
            MugPos = transform;
            heldObj = this.gameObject;
            heldObjRb = heldObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform;
            heldObj.transform.DOMove(holdPos.transform.position,0.75f);
            heldObj.transform.rotation = holdPos.transform.rotation;
            player.GetComponent<PlayerController>().enabled = false;
            Camera.main.GetComponent<InteractManager>().enabled = false;
            MugKeeper mugKeeper = GetComponent<MugKeeper>();
            mugKeeper.InputManager = InputManager.Instance;
            mugKeeper.enabled = true;
            
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }

        string IInscriptionaleObject.Inscription
        {
            get => _inscription;
            set => _inscription = value;
        }

        public void EndInteraction()
        {
            
            heldObjRb.isKinematic = false;
            heldObjRb.transform.parent = null;
            heldObj.transform.DOMove(MugPos.position,0.75f);
            heldObj.transform.rotation = MugPos.rotation;
            player.GetComponent<PlayerController>().enabled = true;
            Camera.main.GetComponent<InteractManager>().enabled = true;
            GetComponent<MugKeeper>().enabled = false;
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        }
    }
}
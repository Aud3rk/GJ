using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

namespace KeyElements
{
    public class KeyHolder : MonoBehaviour, IInterctable
    {
        public int Index;
        public UnityEvent KeyOn;
        public Transform KeyPos; 
        public GameObject key;
        
        public bool KeyIsOn
        {
            get;
            private set;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!KeyIsOn)
            {
                KeyIsOn = true;
                key = other.gameObject;
                Key keyObject = other.gameObject.GetComponent<Key>();
                if (keyObject)
                {
                    keyObject.InHole = true;
                    other.GetComponent<PickUpController>().StopPickUp();
                    other.transform.parent = null;
                    other.transform.position = KeyPos.position;
                    other.transform.rotation = KeyPos.rotation;
                    
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    if(keyObject.Index == Index)
                    {
                        transform.GetComponent<Collider>().enabled = false;
                        KeyOn.Invoke();
                        keyObject.GetComponent<Collider>().enabled = false;
                    }
                        
                } 
                
            }
        }
        public void Interact(GameObject gameObject)
        {
            if (KeyIsOn)
            {
                key.GetComponent<IInterctable>().Interact(gameObject);
                TakeKey();
                
            }
        }
        
        public void TakeKey()
        {
            key.GetComponent<Key>().InHole = false;
            key = null;
            KeyIsOn = false;
        }
    }
    
}
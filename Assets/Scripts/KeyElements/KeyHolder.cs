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
        private GameObject key;

        public GameObject Key
        {
            get { return key; }
            set { key=value;}
        }
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
                    other.transform.localScale = KeyPos.localScale;
                    
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    if(keyObject.Index == Index)
                        KeyOn.Invoke();
                        
                } 
            }
            Debug.Log("some");
        }
        public void Interact(GameObject gameObject)
        {
            if (KeyIsOn)
            {
                Key.GetComponent<IInterctable>().Interact(gameObject);
                TakeKey();
            }
        }
        
        public void TakeKey()
        {
            KeyIsOn = false;
        }

    }
    
}
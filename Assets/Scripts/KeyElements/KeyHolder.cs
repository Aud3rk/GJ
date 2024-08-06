using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

namespace KeyElements
{
    public class KeyHolder : MonoBehaviour
    {
        public int Index;
        public UnityEvent KeyOn;
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
                if (keyObject&&Camera.main.GetComponent<PickUpController>())
                {
                    keyObject.InHole = true;
                    Camera.main.GetComponent<PickUpController>().StopPickUp();
                    other.transform.position = gameObject.transform.position;
                    other.transform.rotation = gameObject.transform.rotation;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    if(keyObject.Index == Index)
                        KeyOn.Invoke();
                        
                } 
            }
            Debug.Log("some");
        }

        public void TakeKey()
        {
            KeyIsOn = false;
        }
    }
    
}
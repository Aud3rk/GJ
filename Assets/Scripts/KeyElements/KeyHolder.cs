using System;
using UnityEngine;

namespace KeyElements
{
    public class KeyHolder : MonoBehaviour
    {
        public int Index;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Key>()&&other.gameObject.GetComponent<Key>().Index == Index&&
                Camera.main.GetComponent<PickUpController>())
            {
                
            }
            else Debug.Log("some shit");
        }
    }
    public class Key : MonoBehaviour
    {
        public int Index;

    }
}
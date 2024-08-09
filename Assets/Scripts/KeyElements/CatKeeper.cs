using System;
using UnityEngine;

namespace KeyElements
{
    public class CatKeeper : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<CatHolder>().enabled = false;
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
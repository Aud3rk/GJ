using System;
using Resources.Scripts;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Events
{
    public class MugKeeper:MonoBehaviour
    {
        public InputManager InputManager;

        private void Update()
        {
            if (InputManager.PlayerPickUp())
            {
                GetComponent<MugController>().EndInteraction();
            }
        }
    }
}
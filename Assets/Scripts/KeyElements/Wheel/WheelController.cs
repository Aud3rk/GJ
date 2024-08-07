using System;
using Resources.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Wheel
{
    public class WheelController : MonoBehaviour
    {
        public UnityEvent WheelCorrect;
        [SerializeField] private float neededRotation;
        public InputManager InputManager { get; set; }
        private void Update()
        {
            if (InputManager.PlayerPickUp())
            {
                gameObject.GetComponent<WheelKeeper>().EndInteract();
            }
            else
            {
                Vector2 movement = InputManager.GetPlayerMovement();
                gameObject.transform.Rotate(0, 0, -movement.x*0.25f);

                if (neededRotation-5<gameObject.transform.rotation.eulerAngles.z&&gameObject.transform.rotation.eulerAngles.z>neededRotation)
                {
                    WheelCorrect.Invoke();
                }

            }
            
        }

        public void WheelIsCorrect()
        {
            Debug.Log("Руль поставлен");
        }

    }
}
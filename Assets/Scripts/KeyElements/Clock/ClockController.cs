using Resources.Scripts;
using UnityEngine;

namespace KeyElements
{
    public class ClockController : MonoBehaviour
    {
        public InputManager InputManager;
        public GameObject HourArrow;
        public GameObject MinuteArrow;
        public GameObject SecondArrow;
        

        private void Update()
        {
            if (InputManager.PlayerPickUp())
            {
                gameObject.GetComponent<ClockRoom2>().EndInteract();
            }
        }
    }
}
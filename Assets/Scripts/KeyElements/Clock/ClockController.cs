using Cube;
using DG.Tweening;
using Resources.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace KeyElements
{
    public class ClockController : MonoBehaviour
    {
        public GameObject Clock;
        public GameObject Clock2;
        
        public InputManager InputManager;
        public GameObject HourArrow;
        public GameObject MinuteArrow;
        public GameObject SecondArrow;
        public float rotationH;
        public float rotationM;
        public float rotationS;
        
        ArrowController _arrowController;
        private GameObject Arrow;
        private int correct = 3;
        public UnityEvent ClockCorrect;


        private void Update()
        {
            if (InputManager.Instance.PlayerPickUp())
            {
                gameObject.GetComponent<ClockRoom2>().EndInteract();
            }

            if (InputManager.Instance.Pick())
            {
                GetComponent<Collider>().enabled = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.CompareTag("Arrow"))
                        Arrow = hit.transform.gameObject;

                    }
            }

            if (Arrow != null)
            {
                Vector2 movement = InputManager.Instance.GetPlayerMovement();
                Arrow.transform.Rotate(0, 0, -movement.x*0.25f);
                if (rotationH - 2 < HourArrow.transform.rotation.eulerAngles.z &&
                    HourArrow.transform.rotation.eulerAngles.z+2 > rotationH &&
                    rotationM - 2 < MinuteArrow.transform.rotation.eulerAngles.z &&
                    MinuteArrow.transform.rotation.eulerAngles.z+2 > rotationM &&
                    rotationS - 2 < SecondArrow.transform.rotation.eulerAngles.z &&
                    SecondArrow.transform.rotation.eulerAngles.z+2 > rotationS)
                    ClockCorrect.Invoke();
            }
            
        }

        public void EndInteraction()
        {
            DOTween.Sequence().Append(Clock.transform.DOScale(Vector3.zero, 1f)).
                Append(Clock2.transform.DOScale(Vector3.zero, 1f));
            GetComponent<ClockRoom2>().EndInteract();
        }
    }
}
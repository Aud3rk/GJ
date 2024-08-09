using DG.Tweening;
using UnityEngine;

namespace KeyElements
{
    public class OpenDoorRight : MonoBehaviour
    {
        public void OpenDoor()
        {
            transform.DOMove(new Vector3(transform.position.x, transform.position.y, transform.position.z-1.8f), 3f);
        }
    }
}
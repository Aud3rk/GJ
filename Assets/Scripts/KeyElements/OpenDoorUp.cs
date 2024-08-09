using DG.Tweening;
using UnityEngine;

namespace KeyElements
{
    public class OpenDoorUp : MonoBehaviour
    {
        public void OpenDoor()
        {
            transform.DOMove(new Vector3(transform.position.x+1.8f, transform.position.y, transform.position.z), 3f);
        }
        
    }
}
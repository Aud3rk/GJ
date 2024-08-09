using DG.Tweening;
using UnityEngine;

namespace KeyElements
{
    public class OpenDoor : MonoBehaviour
    {
        public void OpenDoorAnim()
        {
            transform.DORotate(new Vector3(0, 175, 0), 3f);
        }
    }
}
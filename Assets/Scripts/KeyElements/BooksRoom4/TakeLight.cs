using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace KeyElements.BooksRoom4
{
    public class TakeLight : MonoBehaviour, IInterctable
    {
        public UnityEvent someEvent;
        public void Interact(GameObject gameObject)
        {
            someEvent.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
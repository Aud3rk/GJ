using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace KeyElements.BooksRoom4
{
    public class PasteLight: MonoBehaviour, IInterctable
    {
        public UnityEvent someEvent;
        public GameObject Tentacle;
        public GameObject Cat;
        
        public void Interact(GameObject gameObject)
        {
            Cat.GetComponent<LampRoom2>()._inscription = "Хочется \"погладить\" котика";
            Tentacle.transform.DOScale(Vector3.zero,2f);
            someEvent.Invoke();
        }
    }
}
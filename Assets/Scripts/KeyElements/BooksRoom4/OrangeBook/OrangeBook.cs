using DefaultNamespace;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace KeyElements.BooksRoom4.OrangeBook
{
    public class OrangeBook : PickUpController,IInscriptionaleObject
    {
        private string _inscription;
        public string inscriptUse= "Напоследок надо погладить кота";
        public string inscriptStatic = "";
        public UnityEvent Event;

        void Start()
        {
            _inscription = inscriptStatic;
        }
        public override void Interact(GameObject gameObject)
        {
            if (heldObj == null)
            {
                _inscription = inscriptUse;
                base.Interact(gameObject);
                Event.Invoke();
                
            }
            else
            {
                _inscription = inscriptStatic;
                base.Interact(gameObject);
                
            }
            
        }

        string IInscriptionaleObject.Inscription
        {
            get => _inscription;
            set => _inscription = value;
        }
    }
}
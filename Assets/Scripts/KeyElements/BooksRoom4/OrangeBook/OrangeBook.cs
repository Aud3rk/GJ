using DefaultNamespace;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace KeyElements.BooksRoom4.OrangeBook
{
    public class OrangeBook : PickUpController,IInscriptionaleObject
    {
        private string _inscription;
        public string inscript="Напоследок надо погладить кота";
        public UnityEvent Event;
        
        public override void Interact(GameObject gameObject)
        {
            if (heldObj == null)
            {
                _inscription = inscript;
                base.Interact(gameObject);
                Event.Invoke();
                
            }
            else
            {
                _inscription = "";
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
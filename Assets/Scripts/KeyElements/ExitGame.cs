using DefaultNamespace;
using UnityEngine;

namespace KeyElements
{
    public class ExitGame : MonoBehaviour, IInterctable, IInscriptionaleObject
    {
        private string _inscription= "Это конец?";

        public void Interact(GameObject gameObject)
        {
            Application.Quit();
        }

        string IInscriptionaleObject.Inscription
        {
            get => _inscription;
            set => _inscription = value;
        }
    }
}
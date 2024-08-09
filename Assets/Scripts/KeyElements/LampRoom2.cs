using DefaultNamespace;
using UnityEngine;

namespace KeyElements
{
    public class LampRoom2 : MonoBehaviour, IInscriptionaleObject
    {
        
        public string _inscription  = "Лишь свет укажет нужный путь";

        string IInscriptionaleObject.Inscription
        {
            get => _inscription;
            set => _inscription = value;
        }
    }
}
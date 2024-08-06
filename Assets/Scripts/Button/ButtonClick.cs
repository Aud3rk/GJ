using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ButtonClick : MonoBehaviour, IInterctable, IInscriptionaleObject
{
    private string _inscription="Я кнопка сцука";

    public void Interact(GameObject gameObject)
    {
        Debug.Log("хуй");
    }

    string IInscriptionaleObject.Inscription
    {
        get => _inscription;
        set => _inscription = value;
    }
}

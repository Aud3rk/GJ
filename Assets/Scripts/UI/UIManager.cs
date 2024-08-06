using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _interactText;

    private static UIManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    
    public static UIManager Instance
    {
        get { return _instance; }
    }

    public void EnableInteractText()
    {
        _interactText.SetActive(true);
    }

    public void DisableInteractText()
    {
        _interactText.SetActive(false);
    }
}
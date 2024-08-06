using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class InteractView : MonoBehaviour
{
    private UIManager _uimanager;

    void Start()
    {
        _uimanager = UIManager.Instance;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Interactables") && hit.distance <= 1.5f)
            {
                _uimanager.EnableInteractText();
            }
            else {
                _uimanager.DisableInteractText();
            }
        }
        
    }
}
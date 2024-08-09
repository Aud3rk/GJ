using System;
using DG.Tweening;
using Resources.Scripts;
using UnityEditor;
using UnityEngine;

namespace KeyElements
{
    public class ArrowController : MonoBehaviour
    {
        private InputManager _inputManager;

        private void OnEnable()
        {
            _inputManager = InputManager.Instance;
        }

        private void Update()
        {
            Vector2 movement = _inputManager.GetPlayerMovement();
            gameObject.transform.Rotate(0, 0, -movement.x*0.25f);

            

        }

    }
}
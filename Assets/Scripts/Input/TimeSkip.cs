using System;
using Cinemachine;
using UnityEngine;

namespace Resources.Scripts
{
    public class TimeSkip : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera camPast;
        [SerializeField] private CinemachineVirtualCamera camNow;
        
        private InputManager InputManager;

        private void Start()
        {
            InputManager = InputManager.Instance;
            
        }

        private void Update()
        {
            if (InputManager.TimeSkip())
            {
                
                camPast.Priority = -camPast.Priority;
                camNow.Priority = -camNow.Priority;
                
            }
        }
    }
}
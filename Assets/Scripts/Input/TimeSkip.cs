using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Resources.Scripts
{
    public class TimeSkip : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera camPast;
        [SerializeField] private CinemachineVirtualCamera camNow;
        
        private InputManager InputManager;
        private CameraSwitchTimeAnimation _camAnim;

        private void Start()
        {
            InputManager = InputManager.Instance;
            _camAnim = Camera.main.GetComponent<CameraSwitchTimeAnimation>();

        }

        private void Update()
        {
            if (InputManager.TimeSkip())
            {
                _camAnim.GoInTimeAnimation();
                StartCoroutine(ChangeCams());
                //ChangeCams();
            }
        }

        public IEnumerator ChangeCams()
        {
            yield return new WaitForSeconds(1f);
            camPast.Priority = -camPast.Priority;
            camNow.Priority = -camNow.Priority;
        }
    }
}
using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameBootStrap :MonoBehaviour, ICoroutineRunner
    {
        private static GameBootStrap _instance;

        public static GameBootStrap Instance
        {
            get { return _instance; }
            
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    }
}
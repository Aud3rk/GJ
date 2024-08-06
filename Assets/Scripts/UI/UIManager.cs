using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIManager:MonoBehaviour
    {
        public TMP_Text Inscription;
        private static UIManager _instance;

        public static UIManager Instance
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
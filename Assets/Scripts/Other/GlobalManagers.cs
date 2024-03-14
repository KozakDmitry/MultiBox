﻿using UnityEngine;

namespace Scripts.Lobby
{
    public class GlobalManagers : MonoBehaviour
    {
        public static GlobalManagers Instance { get; private set; }

        [SerializeField] private GameObject parentObject;
        [field: SerializeField]
        public NetworkRunnerController networkRunnerController { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(parentObject);
            }
        }
    }
}
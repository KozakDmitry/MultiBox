using Scripts.Other;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Lobby
{
    public class LoadingCanvasController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Button cancelButton;

        private NetworkRunnerController networkRunnerController;


        private void Start()
        {
            networkRunnerController = GlobalManagers.Instance.networkRunnerController;
            networkRunnerController.OnStartedRunnerCollection += OnStartedRunnerConnection;
            networkRunnerController.OnPlayerJoinedSuccessfully += OnPlayerJoinedSuccessfully;
            cancelButton.onClick.AddListener(networkRunnerController.ShutDownRunner);
            this.gameObject.SetActive(false);
        }

        private void OnPlayerJoinedSuccessfully()
        {
            StartCoroutine(Utilities.PlayAnimAndSetStateWhenFinished(gameObject, animator,Utilities.CLIP_NAME_OUT, false));

        }

        private void OnStartedRunnerConnection()
        {
            gameObject.SetActive(true);
            StartCoroutine(Utilities.PlayAnimAndSetStateWhenFinished(gameObject, animator,Utilities.CLIP_NAME_IN));
        }

        private void CancelRequest()
        {
           
        }
        private void OnDestroy()
        {
            networkRunnerController.OnStartedRunnerCollection -= OnStartedRunnerConnection;
            networkRunnerController.OnPlayerJoinedSuccessfully -= OnPlayerJoinedSuccessfully;
        }
    }
}


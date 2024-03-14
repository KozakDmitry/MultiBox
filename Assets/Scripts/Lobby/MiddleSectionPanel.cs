
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Lobby
{
    public class MiddleSectionPanel : LobbyPanelBase
    {
        [Header("MiddleSectionPanel Vars")]
        [SerializeField]
        private Button joinRandomRoomButton;
        [SerializeField]
        private Button joinRoomByArgButton;
        [SerializeField]
        private Button createRoomButton;

        [SerializeField]
        private TMP_InputField joinRoomByArgInputField;
        [SerializeField]
        private TMP_InputField createRoomInputField;
        private NetworkRunnerController networkRunnerController;

        public override void Initialize(LobbyUIManager UIManager)
        {
            base.Initialize(UIManager);
            networkRunnerController = GlobalManagers.Instance.networkRunnerController;
            joinRandomRoomButton.onClick.AddListener(JoinRandomRoom);
            joinRoomByArgButton.onClick.AddListener(() => CreateRoom(GameMode.Client, joinRoomByArgInputField.text));
            createRoomButton.onClick.AddListener(() => CreateRoom(GameMode.Host, createRoomInputField.text));
        }

        private void CreateRoom(GameMode gameMode, string field)
        {
            if (createRoomInputField.text.Length >= 2)
            {
                Debug.Log($"-------------{gameMode}----------------");
                networkRunnerController.StartGame(gameMode, field);
            }
        }


        private void JoinRandomRoom()
        {
            if (createRoomInputField.text.Length >= 2)
            {
                Debug.Log($"-------------JoinedRandomRoom----------------");

                networkRunnerController.StartGame(GameMode.AutoHostOrClient, string.Empty);
            }
        }
    }
}

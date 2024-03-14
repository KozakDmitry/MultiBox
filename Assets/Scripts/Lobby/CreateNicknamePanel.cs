using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Lobby
{
    public class CreateNicknamePanel : LobbyPanelBase
    {
        [Header("CreateNicknamePanel Vars")]
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button CreateNicknameButton;
        private const int MAX_CHAR_FOR_NICKNAME = 2;

        public override void Initialize(LobbyUIManager lobbyUIManager)
        {
            base.Initialize(lobbyUIManager);
            CreateNicknameButton.interactable = false;
            CreateNicknameButton.onClick.AddListener(OnClickCreateNickname);
            inputField.onValueChanged.AddListener(OnInputValueChange);
        }

        private void OnInputValueChange(string arg0)
        {
            CreateNicknameButton.interactable = arg0.Length >= MAX_CHAR_FOR_NICKNAME;
        }

        private void OnClickCreateNickname()
        {
            string nickName = inputField.text;
            if (nickName.Length >= 2)
            {
                base.ClosePanel();
                lobbyUIManager.ShowPanel(LobbyPanelType.MiddleSectionPanel);
            }
        }

    }
}


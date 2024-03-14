using Scripts.Other;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Lobby
{
    public class LobbyPanelBase : MonoBehaviour
    {
        [field:SerializeField, Header("LobbyPanelBase Vars")]
        public LobbyPanelType PanelType { get; private set; }
        [SerializeField]    
        private Animator PanelAnimator;
        protected LobbyUIManager lobbyUIManager;

        const string POP_IN_ClIP_NAME = "In";
        const string POP_OUT_ClIP_NAME = "Out";
        public enum LobbyPanelType
        {
            None,
            CreateNicknamePanel,
            MiddleSectionPanel
        }
        public virtual void Initialize(LobbyUIManager UIManager)
        {
            lobbyUIManager = UIManager;
        }

        public void ShowPanel()
        {
            this.gameObject.SetActive(true);
            
            PanelAnimator.Play(POP_IN_ClIP_NAME);
        }

        protected void ClosePanel()
        {
            PanelAnimator.Play(POP_OUT_ClIP_NAME);
            StartCoroutine(Utilities.PlayAnimAndSetStateWhenFinished(gameObject, PanelAnimator, POP_OUT_ClIP_NAME,false));

        }
    }
}

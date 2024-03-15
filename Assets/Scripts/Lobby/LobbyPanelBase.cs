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
            
            PanelAnimator.Play(Utilities.CLIP_NAME_IN);
        }

        protected void ClosePanel()
        {
            PanelAnimator.Play(Utilities.CLIP_NAME_OUT);
            StartCoroutine(Utilities.PlayAnimAndSetStateWhenFinished(gameObject, PanelAnimator, Utilities.CLIP_NAME_OUT,false));

        }
    }
}

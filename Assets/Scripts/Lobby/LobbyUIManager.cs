using UnityEngine;
using static Scripts.Lobby.LobbyPanelBase;

namespace Scripts.Lobby
{
    public class LobbyUIManager : MonoBehaviour
    {
        [SerializeField]
        private LobbyPanelBase[] lobbyPanels;


        private void Start()
        {
            foreach (var lobby in lobbyPanels)
            {
                lobby.Initialize(this);
            }
        }


        public void ShowPanel(LobbyPanelType type)
        {
            foreach(var lobby in lobbyPanels)
            {
                if(lobby.PanelType == type)
                {
                    lobby.ShowPanel();
                    break;
                }
            }
        }
    }
}


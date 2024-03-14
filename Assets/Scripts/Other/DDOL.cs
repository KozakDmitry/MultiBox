using UnityEngine;

namespace Scripts.Lobby
{
    public class DDOL : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
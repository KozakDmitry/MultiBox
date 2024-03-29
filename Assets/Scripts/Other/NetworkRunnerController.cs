using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class NetworkRunnerController : MonoBehaviour, INetworkRunnerCallbacks
{

    public event Action OnStartedRunnerCollection;
    public event Action OnPlayerJoinedSuccessfully;
    [SerializeField] private NetworkRunner networkRunnerPrefab;

    private NetworkRunner networkRunnerInstance;
    private const string SCENE_NAME = "MainGame";


    public void ShutDownRunner()
    {
        networkRunnerInstance.Shutdown();
    }

    public async void StartGame(GameMode gameMode, string roomName)
    {
        OnStartedRunnerCollection?.Invoke();
        if(networkRunnerInstance == null)
        {
            networkRunnerInstance = Instantiate(networkRunnerPrefab);
        }
        

        networkRunnerInstance.AddCallbacks(this);
        //networkRunnerInstance.ProvideInput = true;

        StartGameArgs startGameArgs = new StartGameArgs()
        {
            GameMode = gameMode,
            SessionName = roomName,
            PlayerCount = 4,
            SceneManager = networkRunnerInstance.GetComponent<INetworkSceneManager>(),
        };


        StartGameResult result = await networkRunnerInstance.StartGame(startGameArgs);
        if (result.Ok)
        {
            await networkRunnerInstance.LoadScene(SCENE_NAME);
        }
        else
        {
            Debug.LogError($"Failed to start:{result.ShutdownReason}");
        }
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("PlayerJoined");
        OnPlayerJoinedSuccessfully?.Invoke();
    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("ConnectedToServer");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("ConnectedFailed");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("ConnectionRequested");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        Debug.Log("Response");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        Debug.Log("Disconnected");
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        Debug.Log("HostMigrated");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        Debug.Log("Input");
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        Debug.Log("InputMissing");
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        Debug.Log("EnterAOI");
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        Debug.Log("ExitAOI");
    }


    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("PlayerLeft");
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        Debug.Log("DataProgress");
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        Debug.Log("DataReceived");
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        Debug.Log("SceneIsLoaded");
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        Debug.Log("SceneStarted");
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("ListUpdated");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("Shutdown");
        SceneManager.LoadScene("Lobby");
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        Debug.Log("OnSimulation");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

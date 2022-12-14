using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedClient : MonoBehaviour
{

    int connectionID;
    int maxConnections = 1000;
    int reliableChannelID;
    int unreliableChannelID;
    int hostID;
    int socketPort = 5491;
    byte error;
    bool isConnected = false;
    int ourClientID;


    [SerializeField]
    GameSystemManager gameSystemManager;
    [SerializeField]
    TicTacToeTable ticTacToeTable;

    public GameStates gameState;
    [SerializeField]
    GameObject[] arrMainMenuItems;

    void Start()
    {
        Connect();
        gameState = GameStates.MainMenu;
    }

    void Update()
    {
        UpdateNetworkConnection();
    }

    private void UpdateNetworkConnection()
    {
        if (isConnected)
        {
            int recHostID;
            int recConnectionID;
            int recChannelID;
            byte[] recBuffer = new byte[1024];
            int bufferSize = 1024;
            int dataSize;
            NetworkEventType recNetworkEvent = NetworkTransport.Receive(out recHostID, out recConnectionID, out recChannelID, recBuffer, bufferSize, out dataSize, out error);

            switch (recNetworkEvent)
            {
                case NetworkEventType.ConnectEvent:
                    Debug.Log("connected.  " + recConnectionID);
                    ourClientID = recConnectionID;
                    break;
                case NetworkEventType.DataEvent:
                    string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                    ProcessRecievedMsg(msg, recConnectionID);
                    break;
                case NetworkEventType.DisconnectEvent:
                    isConnected = false;
                    Debug.Log("disconnected.  " + recConnectionID);
                    break;
            }
        }
    }

    private void Connect()
    {

        if (!isConnected)
        {
            Debug.Log("Attempting to create connection");

            NetworkTransport.Init();

            ConnectionConfig config = new ConnectionConfig();
            reliableChannelID = config.AddChannel(QosType.Reliable);
            unreliableChannelID = config.AddChannel(QosType.Unreliable);
            HostTopology topology = new HostTopology(config, maxConnections);
            hostID = NetworkTransport.AddHost(topology, 0);
            Debug.Log("Socket open.  Host ID = " + hostID);

            connectionID = NetworkTransport.Connect(hostID, "192.168.18.92", socketPort, 0, out error); // server is local on network

            if (error == 0)
            {
                isConnected = true;

                Debug.Log("Connected, id = " + connectionID);

            }
        }
    }

    public void Disconnect()
    {
        NetworkTransport.Disconnect(hostID, connectionID, out error);
    }

    public void SendMessageToHost(string msg)
    {
        byte[] buffer = Encoding.Unicode.GetBytes(msg);
        NetworkTransport.Send(hostID, connectionID, reliableChannelID, buffer, msg.Length * sizeof(char), out error);
    }

    private void ProcessRecievedMsg(string msg, int id)
    {
        Debug.Log("msg recieved = " + msg + ".  connection id = " + id);

        string[] csv = msg.Split(',');
        ServerToClientSignifier _signifier = (ServerToClientSignifier)System.Enum.Parse(typeof(ServerToClientSignifier), csv[0]);

        if (_signifier == ServerToClientSignifier.LoginComplete)
        {
            gameSystemManager.AccessToAccount();
        }
        else if (_signifier == ServerToClientSignifier.GameStart)
        {
            gameState = GameStates.TicTacToe;
            gameSystemManager.StartGame();
        }
        else if (_signifier == ServerToClientSignifier.OpponentPlays)
        {
            Debug.Log("OpponentPlays!!!!");
        }
        else if (_signifier == ServerToClientSignifier.YourTurn)
        {
            ticTacToeTable.isPlayerTurn = true;
        }
        else if (_signifier == ServerToClientSignifier.SetSymbols)
        {
            if (csv[1] == "x")
            {
                ticTacToeTable.playerSymbol = Symbol.X;
                ticTacToeTable.opponentSymbol = Symbol.O;
            }

        }
        else if (_signifier == ServerToClientSignifier.UpdateMarks)
        {
            ticTacToeTable.UpdateTable(csv[1]);
        }
    }

    public bool IsConnected()
    {
        return isConnected;
    }


}
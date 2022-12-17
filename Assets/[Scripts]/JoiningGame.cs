using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoiningGame : MonoBehaviour
{
    [SerializeField]
    NetworkedClient networkedClient;
    [SerializeField]
    GameObject JoinButton;

    public void JoiningGameButton()
    {
        networkedClient.SendMessageToHost(ClientToServerSignifier.JoinQueueFromGameRoom + "");
        networkedClient.gameState = GameStates.OnQueue;
        JoinButton.SetActive(false);
    }
}

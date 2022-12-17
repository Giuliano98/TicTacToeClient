using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    [SerializeField]
    NetworkedClient networkedClient;
    [SerializeField]
    GameObject TicTacToeButton;

    public void TicTacToeGamePlayButton()
    {
        networkedClient.SendMessageToHost(ClientToServerSignifier.TicTacToeGamePlay + "");
        networkedClient.gameState = GameStates.TicTacToe;
        //TicTacToeButton.SetActive(false);
    }
}

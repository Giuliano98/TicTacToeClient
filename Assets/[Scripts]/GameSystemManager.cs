using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystemManager : MonoBehaviour
{
    [SerializeField]
    GameObject FirstLayer;

    [SerializeField]
    GameObject NewAccountLayer;
    [SerializeField]
    GameObject LoggingAccountLayer;

    [SerializeField]
    GameObject joinGameButton;
    [SerializeField]
    GameObject TicTacToeButton;

    public void NewAccountButtonLayer()
    {
        FirstLayer.SetActive(false);
        NewAccountLayer.SetActive(true);
    }
    public void LoginButtonLayer()
    {
        FirstLayer.SetActive(false);
        LoggingAccountLayer.SetActive(true);
    }

    public void BackToMenuFromNewAccount()
    {
        FirstLayer.SetActive(true);
        NewAccountLayer.SetActive(false);
    }

    public void BackToMenuFromLogin()
    {
        FirstLayer.SetActive(true);
        LoggingAccountLayer.SetActive(false);
    }

    public void AccessToAccount()
    {
        LoggingAccountLayer.SetActive(false);
        joinGameButton.SetActive(true);
    }

    public void StartGame()
    {
        joinGameButton.SetActive(false);
        TicTacToeButton.SetActive(true);
    }
}

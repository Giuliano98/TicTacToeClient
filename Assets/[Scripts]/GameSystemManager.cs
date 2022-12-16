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
    GameObject LogingAccountLayer;

    public void NewAccountButtonLayer()
    {
        FirstLayer.SetActive(false);
        NewAccountLayer.SetActive(true);
    }
    public void LoginButtonLayer()
    {
        FirstLayer.SetActive(false);
        LogingAccountLayer.SetActive(true);
    }

    public void BackToMenuFromNewAccount()
    {
        FirstLayer.SetActive(true);
        NewAccountLayer.SetActive(false);
    }

    public void BackToMenuFromLogin()
    {
        FirstLayer.SetActive(true);
        LogingAccountLayer.SetActive(false);
    }

}

enum ClientToServerSignifier
{
    CreatedAccount = 0,
    Login
}

enum ServerToClientSignifier
{
    LoginComplete = 0,
    LoginFailed,
    AccountCreationComplete,
    AccountCreationFailed,

}
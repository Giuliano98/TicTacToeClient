using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginSystemManager : MonoBehaviour
{
    [SerializeField]
    GameObject UsernameInput;
    [SerializeField]
    GameObject PasswordInput;
    [SerializeField]
    NetworkedClient networkedClient;

    TMPro.TMP_InputField userInput;
    TMPro.TMP_InputField passwordInput;

    private void Start()
    {
        userInput = UsernameInput.GetComponent<TMPro.TMP_InputField>();
        passwordInput = PasswordInput.GetComponent<TMPro.TMP_InputField>();
    }

    public void LoginAccountButton()
    {
        string msg = (int)ClientToServerSignifier.Login + "," + userInput.text + "," + passwordInput.text;
        networkedClient.SendMessageToHost(msg);
        Debug.Log(msg);
    }
}

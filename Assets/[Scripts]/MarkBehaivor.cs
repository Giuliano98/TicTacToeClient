using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarkBehaivor : MonoBehaviour
{
    [SerializeField]
    TicTacToeTable ticTacToeTable;
    [SerializeField]
    public bool isEmpty = true;
    [SerializeField]
    public Symbol playerSymbol;
    [SerializeField]
    NetworkedClient networkedClient;

    TMPro.TMP_Text text;

    private void Start()
    {
        text = GetComponentInChildren<TMPro.TMP_Text>();
        if (ticTacToeTable == null)
        {
            ticTacToeTable = GetComponentInParent<TicTacToeTable>();
        }
    }

    public void OnClickMarkBehavior()
    {
        // check for player turn
        if (!ticTacToeTable.isPlayerTurn)
            return;

        if (!isEmpty)
            return;

        // Get the player symbol mark
        playerSymbol = ticTacToeTable.playerSymbol;
        // Mark add mark to the button 
        if (playerSymbol == Symbol.empty)
        {
            text.SetText("ERROR!");
        }
        else if (playerSymbol == Symbol.X)
        {
            text.SetText("X");
        }
        else if (playerSymbol == Symbol.O)
        {
            text.SetText("O");
        }
        //ticTacToeTable.isPlayerTurn = false;
        isEmpty = false;

        // Win check
        if (ticTacToeTable.CheckWinCondition())
        {
            Debug.Log("YOU WIN!");
        }
        else if (ticTacToeTable.CheckDrawGame())
        {
            Debug.Log("DRAW!!!!");
        }
        else
        {
            Debug.Log("NO ONE WINS YET");
        }
        // Send message to server
        networkedClient.SendMessageToHost(ClientToServerSignifier.PlayerPlayed + "");
        networkedClient.SendMessageToHost(ClientToServerSignifier.StringTable + ticTacToeTable.GetTableAsString());
        ticTacToeTable.isPlayerTurn = false;
    }
    public bool CheckSymbolAndIsEmpty(Symbol s)
    {
        bool b = (s == playerSymbol && !isEmpty) ? true : false;
        return b;
    }
    public void SetMark(Symbol symbol, bool empty)
    {
        playerSymbol = symbol;
        isEmpty = empty;
        if (playerSymbol == Symbol.X)
        {
            text.SetText("X");
        }
        else if (playerSymbol == Symbol.O)
        {
            text.SetText("O");
        }
    }


}

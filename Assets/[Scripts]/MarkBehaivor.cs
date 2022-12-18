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
    Symbol playerSymbol;

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
            //% FOR TESTING
            ticTacToeTable.isPlayerTurn = false;
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
        //% FOR TESTING
        if (ticTacToeTable.playerSymbol == Symbol.X)
            ticTacToeTable.playerSymbol = Symbol.O;
        else
            ticTacToeTable.playerSymbol = Symbol.X;
    }
    public bool CheckSymbolAndIsEmpty(Symbol s)
    {
        bool b = (s == playerSymbol && !isEmpty) ? true : false;
        return b;
    }


}

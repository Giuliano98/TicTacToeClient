using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Symbol
{
    empty,
    X,
    O
}
public class TicTacToeTable : MonoBehaviour
{
    [SerializeField]
    public Symbol playerSymbol;
    [SerializeField]
    public bool isPlayerTurn;
    [SerializeField]
    MarkBehaivor[] markBehaivor;

    private void Start()
    {
        isPlayerTurn = true;
        playerSymbol = Symbol.X;
    }

    public bool CheckWinCondition()
    {
        if (markBehaivor[0].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[1].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[2].CheckSymbolAndIsEmpty(playerSymbol))
            return true;
        else if (markBehaivor[3].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[4].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[5].CheckSymbolAndIsEmpty(playerSymbol))
            return true;
        else if (markBehaivor[6].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[7].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[8].CheckSymbolAndIsEmpty(playerSymbol))
            return true;

        else if (markBehaivor[0].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[3].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[6].CheckSymbolAndIsEmpty(playerSymbol))
            return true;
        else if (markBehaivor[1].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[4].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[7].CheckSymbolAndIsEmpty(playerSymbol))
            return true;
        else if (markBehaivor[2].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[5].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[8].CheckSymbolAndIsEmpty(playerSymbol))
            return true;

        else if (markBehaivor[0].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[4].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[8].CheckSymbolAndIsEmpty(playerSymbol))
            return true;
        else if (markBehaivor[2].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[4].CheckSymbolAndIsEmpty(playerSymbol) &&
        markBehaivor[6].CheckSymbolAndIsEmpty(playerSymbol))
            return true;


        return false;
    }

    public bool CheckDrawGame()
    {
        bool b = true;
        foreach (var mark in markBehaivor)
        {
            if (mark.isEmpty)
            {
                b = false;
                break;
            }
        }
        return b;
    }

}

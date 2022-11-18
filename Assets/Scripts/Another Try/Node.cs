using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Board boardInNode;
    public List<Node> children;

    char ai = 'X';
    char human = '0';

    public char currentPlayer;

    
    private void Start() {

        currentPlayer = ai;
    }


    public void MinimaxCall(Board b) {

        boardInNode = b;
        children = new List<Node>();

        int bestScore = -1000;
        int bestRowMove = -1;
        int bestColMove = -1;

        for (int row = 0; row < 3; ++row) {

            for (int col = 0; col < 3; ++col) {

                if (b.grid[row, col] == ' ') {

                    Board newBoard = b.Clone();
                    newBoard.SetChar(ai, row, col);
                    int _score = Minimax(newBoard, false);

                    if (_score > bestScore && currentPlayer == ai) {

                        currentPlayer = human;
                        bestScore = _score;
                        bestRowMove = row;
                        bestColMove = col;
                        Debug.Log(row + ", " + col);
                        b.SetChar('X', bestRowMove, bestColMove);
                        boardInNode = b;
                    }
                }
            }
        }
    }


    public int Minimax(Board b, bool isMaximizing) {

        if (b.GetState() != 0) {

            return b.GetState();
        }
        else if (isMaximizing) {

            int bestScore = -1000;

            for (int row = 0; row < 3; ++row) {
                for (int col = 0; col < 3; ++col) {

                    if (b.grid[row, col] == ' ') {

                        Board newBoard = b.Clone();
                        newBoard.SetChar(ai, row, col);
                        int _score = Minimax(newBoard, false);

                        if (_score > bestScore) {

                            bestScore = _score;
                        }
                    }
                }
            }
            return bestScore;
        }
        else {

            int bestScore = 1000;

            for (int row = 0; row < 3; ++row) {
                for (int col = 0; col < 3; ++col) {

                    if (b.grid[row, col] == ' ') {

                        Board newBoard = b.Clone();
                        newBoard.SetChar(human, row, col);
                        int _score = Minimax(newBoard, true);

                        if (_score < bestScore) {

                            bestScore = _score;
                        }
                    }
                }
            }
            return bestScore;
        }
    }
    

    public bool CompareMiniMaxBoards(Board b) {

        if (boardInNode == b) {  //Equals(boardInNode)) {

            return true;
        }
        return false;
    }
}

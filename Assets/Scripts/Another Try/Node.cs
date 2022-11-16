using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public int score = 0;
    public int height;
    public Board boardInNode;
    public List<Node> children;

    char ai = 'X';
    char human = '0';

    char currentPlayer;

    /*
    public Node(int height, Board b)
    {

        this.boardInNode = b;
        this.height = height;
        children = new List<Node>();

        int _score = 0;


        if (b.GetState() == 0)
        {

            float bestScore = -1000;
            int bestRowMove = -1;
            int bestColMove = -1;

            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {


                    if (b.grid[row, col] == ' ')
                    {

                        Board newBoard = b.Clone();
                        newBoard.SetChar('X', row, col);
                        _score = Minimax(newBoard, 0, false);

                        if (_score > bestScore)
                        {

                            bestScore = score;
                            bestRowMove = row;
                            bestColMove = col;
                        }
                    }
                }
            }

            b.SetChar('X', bestRowMove, bestColMove);
        }
    }
    */
    private void Start() {

        currentPlayer = ai;
    }

    public void MinimaxCall(int height, Board b) {

        this.boardInNode = b;
        this.height = height;
        children = new List<Node>();

        int _score = 0;


        if (b.GetState() == 0)
        {

            float bestScore = 0;
            int bestRowMove = -1;
            int bestColMove = -1;

            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {


                    if (b.grid[row, col] == ' ')
                    {

                        Board newBoard = b.Clone();
                        newBoard.SetChar('X', row, col);
                        _score = Minimax(newBoard, 0, false);

                        if (_score > bestScore)
                        {

                            bestScore = score;
                            bestRowMove = row;
                            bestColMove = col;
                        }
                    }
                }
            }

            b.SetChar('X', bestRowMove, bestColMove);
        }
    }



    public int Minimax(Board b, int h, bool isMaximizing) {

        int _score = 0;

        if (b.GetState() != 0) {

            return _score;
        }

        if (isMaximizing)
        {

            int bestScore = -1000;

            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {


                    if (b.grid[row, col] == ' ')
                    {

                        Board newBoard = b.Clone();
                        newBoard.SetChar('X', row, col);
                        _score = Minimax(newBoard, h + 1, false);

                        if (_score > bestScore) {

                            bestScore = score;
                        }
                    }
                }
            }
            Debug.Log(bestScore);
            return bestScore;
        }
        else
        {
            int bestScore = 1000;

            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {


                    if (b.grid[row, col] == ' ')
                    {

                        Board newBoard = b.Clone();
                        newBoard.SetChar('0', row, col);
                        _score = Minimax(newBoard, 0, true);

                        if (_score > bestScore)
                        {

                            bestScore = score;
                        }
                    }
                }
            }
            return bestScore;
        }
    }
}

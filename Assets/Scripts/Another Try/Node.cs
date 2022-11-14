using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Tree {


    public int score = 0;
    public int height;
    public Board board;
    public List<Node> children;

    Vector2 bestMove;


    public Node(int height, Board b) {

        this.board = b;
        this.height = height;
        children = new List<Node>();

        int _score = 0;


        if (b.GetState() == 0) {

            float bestScore = Mathf.NegativeInfinity;


            for (int row = 0; row < 3; ++row) {

                for (int col = 0; col < 3; ++col) {


                    if (b._board[row, col] == ' ') {

                        Board newBoard = b.Clone();
                        newBoard.SetChar('X', col, row);

                        _score = Minimax(newBoard, height, false);

                        if (_score > bestScore) {

                            bestScore = _score;
                            b.SetChar('X', row, col);
                            bestMove = new Vector2(row, col);
                        }

                        Node newNode = new Node(this.height + 1, newBoard);
                        children.Add(newNode);


                        if (newNode.score > _score)
                            _score = newNode.score - 1;
                    }
                }
            }
        }
        else if (board.GetState() == 1) {

            score = 18 - height;
        }
        else if (board.GetState() == -1) {

            score = -1 * (-18 + height);
        }
        Debug.Log(children.Count);
    }


    int Minimax(Board b, int h, bool isMaximizing) {

        int _score = 0;

        if (b.GetState() != 0) {

            _score = b.GetState();
        }

        if (isMaximizing) {

            float bestScore = Mathf.NegativeInfinity;

            for (int row = 0; row < 3; ++row) {

                for (int col = 0; col < 3; ++col) {


                    if (b._board[row, col] == ' ') {

                        b.SetChar('X', row, col);
                        _score = Minimax(b, h + 1, false);
                        b.SetChar(' ', row, col);

                        if (_score > bestScore) {

                            bestScore = _score;
                            b.SetChar('X', row, col);
                            bestMove = new Vector2(row, col);
                        }
                    }
                }
            }
            return (int)bestScore;
        }
        else {

            float bestScore = Mathf.Infinity;

            for (int row = 0; row < 3; ++row) {

                for (int col = 0; col < 3; ++col) {


                    if (b._board[row, col] == ' ') {

                        b.SetChar('0', row, col);
                        _score = Minimax(b, h + 1, true);
                        b.SetChar(' ', row, col);

                        if (_score < bestScore) {

                            bestScore = _score;
                            b.SetChar('0', row, col);
                            bestMove = new Vector2(row, col);
                        }
                    }
                }
            }
            return (int)bestScore;
        }
    }
}

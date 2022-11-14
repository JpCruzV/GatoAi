using System.Collections;
using System.Collections.Generic;

public class Board {

    public char[,] _board;
    public int state = 0;


    public Board() {

        this._board = new char[3, 3];

        for (int row = 0; row < 3; ++row) {

            for (int col = 0; col < 3; ++col) {

                _board[row, col] = ' ';
            }
        }
    }



    public int GetState () {

        for (int i = 0; i < 3; ++i) {


            if (_board[i, 0] == 'X' && _board[i, 1] == 'X' && _board[i, 2] == 'X') {

                state = 1;
            }
            else if (_board[i, 0] == '0' && _board[i, 1] == '0' && _board[i, 2] == '0') {

                state = -1;
            }


            if (_board[0, i] == 'X' && _board[1, i] == 'X' && _board[2, i] == 'X') {

                state = 1;
            }
            else if (_board[0, i] == '0' && _board[1, i] == '0' && _board[2, i] == '0') {

                state = -1;
            }
        }


        if (_board[0, 0] == 'X' && _board[1, 1] == 'X' && _board[2, 2] == 'X') {

            state = 1;
        }
        else if (_board[0, 2] == 'X' && _board[1, 1] == 'X' && _board[2, 0] == 'X') {

            state = 1;
        }


        if (_board[0, 0] == '0' && _board[1, 1] == '0' && _board[2, 2] == '0') {

            state = -1;
        }
        else if (_board[0, 2] == '0' && _board[1, 1] == '0' && _board[2, 0] == '0') {

            state = -1;
        }

        return state;
    }



    public char SetChar(char character, int x, int y) {

        _board[x, y] = character;
        return character;
    }



    public bool Equals(Board b) {

        for (int row = 0; row < 3; ++row) {

            for (int col = 0; col < 3; col++) {


                if (b.SetChar('X', col, row) == SetChar('X', col, row) && b.SetChar('O', col, row) == SetChar('O', col, row)) {

                    return true;
                }
                else if (b.SetChar('X', col, row) != SetChar('X', col, row) || b.SetChar('O', col, row) != SetChar('O', col, row)) {

                    return false;
                }
            }
        }
        return false;
    }



    public Board Clone() {

        Board boardClone = new Board();

        for (int i = 0; i < 3; ++i) {

            for (int j = 0; j < 3; ++j) {

                boardClone.SetChar(_board[i, j], i, j);
            }
        }

        return boardClone;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public char[,] grid;
    public int state = 0;


    public Board() {

        this.grid = new char[3, 3];

        for (int row = 0; row < 3; ++row) {

            for (int col = 0; col < 3; ++col) {

                grid[row, col] = ' ';
            }
        }
    }


    public int GetState () {

        for (int i = 0; i < 3; ++i) {


            if (grid[i, 0] == 'X' && grid[i, 1] == 'X' && grid[i, 2] == 'X') {

                state = 1;
            }
            else if (grid[i, 0] == '0' && grid[i, 1] == '0' && grid[i, 2] == '0') {

                state = -1;
            }


            if (grid[0, i] == 'X' && grid[1, i] == 'X' && grid[2, i] == 'X') {

                state = 1;
            }
            else if (grid[0, i] == '0' && grid[1, i] == '0' && grid[2, i] == '0') {

                state = -1;
            }
        }


        if (grid[0, 0] == 'X' && grid[1, 1] == 'X' && grid[2, 2] == 'X') {

            state = 1;
        }
        else if (grid[0, 2] == 'X' && grid[1, 1] == 'X' && grid[2, 0] == 'X') {

            state = 1;
        }


        if (grid[0, 0] == '0' && grid[1, 1] == '0' && grid[2, 2] == '0') {

            state = -1;
        }
        else if (grid[0, 2] == '0' && grid[1, 1] == '0' && grid[2, 0] == '0') {

            state = -1;
        }

        return state;
    }


    public char SetChar(char character, int x, int y) {

        if (grid[x, y] == ' ') {

            grid[x, y] = character;
            return character;
        }
        return ' ';
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

                boardClone.SetChar(grid[i, j], i, j);
            }
        }

        return boardClone;
    }
}

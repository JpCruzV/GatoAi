using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour {


    public char[,] tablero;
    public int estado;


    public Tablero() {

        this.tablero = new char[3, 3];

        for (int linea = 0; linea < 3; ++linea) {

            for (int col = 0; col < 3; ++col) {

                tablero[linea, col] = ' ';
            }
        }
    }



    public void calcularEstado() {


        for (int i = 0; i < 3; ++i) {


            if (tablero[i, 0] == 'X' && tablero[i, 1] == 'X' && tablero[i, 2] == 'X') {

                estado = 1;
            }
            else if (tablero[i, 0] == '0' && tablero[i, 1] == '0' && tablero[i, 2] == '0') {

                estado = -1;
            }


            if (tablero[0, i] == 'X' && tablero[1, i] == 'X' && tablero[2, i] == 'X') {

                estado = 1;
            }
            else if (tablero[0, i] == '0' && tablero[1, i] == '0' && tablero[2, i] == '0') {

                estado = -1;
            }
        }


        if (tablero[0, 0] == 'X' && tablero[1, 1] == 'X' && tablero[2, 2] == 'X') {

            estado = 1;
        }
        else if (tablero[0, 2] == 'X' && tablero[1, 1] == 'X' && tablero[2, 0] == 'X') {

            estado = 1;
        }


        if (tablero[0, 0] == '0' && tablero[1, 1] == '0' && tablero[2, 2] == '0') {

            estado = -1;
        }
        else if (tablero[0, 2] == '0' && tablero[1, 1] == '0' && tablero[2, 0] == '0') {

            estado = -1;
        }
    }



    public char setPosition(char character, int x, int y) {

        tablero[x, y] = character;
        return character;
    }



    public int getEstado() {

        return estado;
    }

    public bool Equals(Tablero board) 
    {
        for (int row = 0; row < 3; ++row)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board.setPosition('X', col, row) == setPosition('X', col, row) && board.setPosition('O', col, row) == setPosition('O', col, row))
                {
                    return true;
                }
                else if (board.setPosition('X', col, row) != setPosition('X', col, row) || board.setPosition('O', col, row) != setPosition('O', col, row))
                {
                    return false;
                }
            }
        }
        return false;
    }

    public Tablero cloneTablero() {

        Tablero tablero2 = new Tablero();

        for (int i = 0; i < 3; ++i) {

            for (int j = 0; j < 3; ++j) {

                tablero2.setPosition(tablero[i, j], i, j);
            }
        }
        return tablero2;
    }
}

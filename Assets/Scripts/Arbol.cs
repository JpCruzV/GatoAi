using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour {


    public int score;
    public int height;
    public Tablero board;
    public List<Arbol> children;


    public Arbol(int height, Tablero board) {


        this.board = board;
        this.height = height;
        children = new List<Arbol>();


        if (board.getEstado() == 0) {

            score = 0;


            for (int row = 0; row < 3; ++row) {

                for (int col = 0; col < 3; ++col) {


                    if (this.board.setPosition(' ', col, row) == ' ') {

                        Tablero newBoard = this.board.cloneTablero();


                        if (height % 2 == 0) {

                            newBoard.setPosition('X', col, row);
                        }
                        else {

                            newBoard.setPosition('O', col, row);
                        }


                        Arbol newNode = new Arbol(this.height + 1, newBoard);
                        children.Add(newNode);


                        if (newNode.score > score)
                            score = newNode.score - 1;
                    }
                }
            }
        }
        else if (board.getEstado() == 1) {

            score = 18 - height;
        }
        else if (board.getEstado() == -1) {

            //score = -10 + height;
        }
    }
    /*
    public Arbol FindNodeInChildren(Board board)
    {
    // Busca cuál de los hijos del currentNode tiene un tablero igual al parametro board
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour
{

    public Node root;
    Node currentNode;

    public class Node
    {

        public int score;
        public int height;
        public Tablero board;
        public List<Node> children;


        public Node(int height, Tablero board)
        {

            this.board = board;
            this.height = height;
            children = new List<Node>();


            if (board.getEstado() == 0)
            {

                score = 0;


                for (int row = 0; row < 3; ++row)
                {

                    for (int col = 0; col < 3; ++col)
                    {


                        if (this.board.setPosition(' ', col, row) == ' ')
                        {

                            Tablero newBoard = this.board.cloneTablero();


                            if (height % 2 == 0)
                            {

                                newBoard.setPosition('X', col, row);
                            }
                            else
                            {

                                newBoard.setPosition('O', col, row);
                            }


                            Node newNode = new Node(this.height + 1, newBoard);
                            children.Add(newNode);


                            if (newNode.score > score)
                                score = newNode.score - 1;
                        }
                    }
                }
            }
            else if (board.getEstado() == 1)
            {

                score = 18 - height;
            }
            else if (board.getEstado() == -1)
            {

                score = -1 * (-18 + height);
            }
        }
    }
    public Node FindNodeInChildren(Tablero _board)
    {
        // Busca cuál de los hijos del currentNode tiene un tablero igual al parametro board
        if (root.children.Count == 0)
        {

            return root;
        }
        else
        {
            root = currentNode.children[0];
            
            foreach (Node x in currentNode.children)
            {

                if (x.board == _board)
                {
                    currentNode = x;
                    return currentNode;
                }
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : GameManager {


    public Node root;
    Node currentNode;


    public Node FindNodeInChildren(Board b) {

        if (root.children.Count == 0) {

            return root;
        }
        else {

            root = currentNode.children[0];

            foreach (Node x in currentNode.children) {

                if (x.boardInNode.Equals(b)) {

                    currentNode = x;
                    return currentNode;
                }
            }
        }
        return null;
    }
}

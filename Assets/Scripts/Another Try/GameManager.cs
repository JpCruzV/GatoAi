using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public Text winnerText;

    public int turn;
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;
    public Button[] ticTacToeSpaces;
    
    public Board board;
    public Node node;
    public Tree tree;


    bool one = false;
    bool two = false;
    bool three = false;
    bool four = false;
    bool five = false;
    bool six = false;
    bool seven = false;
    bool eight = false;
    bool nine = false;



    private void Start() {

        GameSetUp();
    }


    private void Update() {
        
        if (turn == 0) {

            //Debug.Log(board.grid[0, 0]);
            //Debug.Log(board.grid[0, 1]);
            //Debug.Log(board.grid[0, 2]);

            node.MinimaxCall(0, board);
            //Debug.Log(node.CompareMiniMaxBoards(board));
            //tree.FindNodeInChildren(board);
            AIMoves('X');
        }

        if (Winner() == true && Input.GetKeyDown(KeyCode.Space)) {

            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {

            Application.Quit();
        }
    }


    void GameSetUp() {

        turn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);

        for (int i = 0; i < ticTacToeSpaces.Length; ++i) {

            ticTacToeSpaces[i].interactable = true;
            ticTacToeSpaces[i].GetComponent<Image>().sprite = null;
        }
    }


    public void TicTacToeBtn(int btn) {

        Debug.Log(turn);
        Debug.Log(node.currentPlayer);

        if (board.GetState() == 0) {

            ticTacToeSpaces[btn].image.sprite = playerIcons[turn];
            ticTacToeSpaces[btn].interactable = false;

            turnCount++;

            if (turn == 0) {

                turn = 1;
                turnIcons[0].SetActive(false);
                turnIcons[1].SetActive(true);
                AlignBoardsOnButtonPressed(btn, 'X');
            }
            else {

                node.currentPlayer = 'X';
                turn = 0;
                turnIcons[0].SetActive(true);
                turnIcons[1].SetActive(false);
                AlignBoardsOnButtonPressed(btn, '0');
            }
        }
        Winner();
    }


    bool Winner() {

        if (board.GetState() == 1) {

            winnerText.text = "X Wins"; 
            return true;
        }
        else if (board.GetState() == -1) {

            winnerText.text = "O Wins";
            return true;
        }
        else if (turnCount >= 9) {

            winnerText.text = "Tie";
            return true;
        }
        else {

            return false;
        }
    }

    
    void AlignBoardsOnButtonPressed(int btn, char simbol) {

        if (btn == 0)
            board.SetChar(simbol, 0, 0);

        else if (btn == 1)
            board.SetChar(simbol, 0, 1);

        else if (btn == 2)
            board.SetChar(simbol, 0, 2);

        else if (btn == 3)
            board.SetChar(simbol, 1, 0);

        else if (btn == 4)
            board.SetChar(simbol, 1, 1);

        else if (btn == 5)
            board.SetChar(simbol, 1, 2);

        else if (btn == 6)
            board.SetChar(simbol, 2, 0);

        else if (btn == 7)
            board.SetChar(simbol, 2, 1);

        else if (btn == 8)
            board.SetChar(simbol, 2, 2);

        else
            Debug.Log("Error Aligning");
    }

    
    void AIMoves(char simbol) {


        if (board.grid[0,0] == simbol && one == false) {

            one = true;
            ticTacToeSpaces[0].onClick.Invoke();
        }
        else if (board.grid[0, 1] == simbol && two == false) {

            two = true;
            ticTacToeSpaces[1].onClick.Invoke();
        }
        else if (board.grid[0, 2] == simbol && three == false) {

            three = true;
            ticTacToeSpaces[2].onClick.Invoke();
        }
        else if (board.grid[1, 0] == simbol && four == false) {

            four = true;
            ticTacToeSpaces[3].onClick.Invoke();
        }
        else if (board.grid[1, 1] == simbol && five == false) {

            five = true;
            ticTacToeSpaces[4].onClick.Invoke();
        }
        else if (board.grid[1, 2] == simbol && six == false) {

            six = true;
            ticTacToeSpaces[5].onClick.Invoke();
        }
        else if (board.grid[2, 0] == simbol && seven == false) {

            seven = true;
            ticTacToeSpaces[6].onClick.Invoke();
        }
        else if (board.grid[2, 1] == simbol && eight == false) {

            eight = true;
            ticTacToeSpaces[7].onClick.Invoke();
        }
        else if (board.grid[2, 2] == simbol && nine == false) {

            nine = true;
            ticTacToeSpaces[8].onClick.Invoke();
        }

        else
            Debug.Log("Error clicking");
    }
}

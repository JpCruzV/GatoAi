using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text winnerText;

    public int turn;
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;
    public Button[] ticTacToeSpaces;

    public Board _board_;


    private void Start() {

        GameSetUp();
    }


    private void Update() {
        
        if (turn == 0) {

            AIMoves('X');
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


        ticTacToeSpaces[btn].image.sprite = playerIcons[turn];
        ticTacToeSpaces[btn].interactable = false;

        turnCount++;

        if (turnCount > 4) {

            Winner();
        }

        if (turn == 0) {

            turn = 1;
            AlignBoards(btn, 'X');
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else {

            AlignBoards(btn, '0');
            turn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }


    void Winner() {

        if (_board_.GetState() == 0) {

            winnerText.text = "Tie";
        }
        else if (_board_.GetState() == 1) {

            winnerText.text = "X Wins";
            Debug.Log("X Wins");
        }
        else if (_board_.GetState() == -1) {

            winnerText.text = "O Wins";
            Debug.Log("O Wins");
        }
    }


    void AlignBoards(int btn, char simbol) {

        if (btn == 0) 
            _board_.SetChar(simbol, 0, 0);
        
        else if (btn == 1) 
            _board_.SetChar(simbol, 0, 1);
        
        else if (btn == 2)
            _board_.SetChar(simbol, 0, 2);

        else if (btn == 3)
            _board_.SetChar(simbol, 1, 0);

        else if (btn == 4)
            _board_.SetChar(simbol, 1, 1);

        else if (btn == 5)
            _board_.SetChar(simbol, 1, 2);

        else if (btn == 6)
            _board_.SetChar(simbol, 2, 0);

        else if (btn == 7)
            _board_.SetChar(simbol, 2, 1);

        else if (btn == 8)
            _board_.SetChar(simbol, 2, 2);
    }


    void AIMoves(char simbol) {

        if (_board_._board[0,0] == simbol) {

            ticTacToeSpaces[0].onClick.Invoke();
        }
        else if (_board_._board[0, 1] == simbol)
        {

            ticTacToeSpaces[1].onClick.Invoke();
        }
        else if (_board_._board[0, 2] == simbol)
        {

            ticTacToeSpaces[2].onClick.Invoke();
        }
        else if (_board_._board[1, 0] == simbol)
        {

            ticTacToeSpaces[3].onClick.Invoke();
        }
        else if (_board_._board[1, 1] == simbol)
        {

            ticTacToeSpaces[4].onClick.Invoke();
        }
        else if (_board_._board[1, 2] == simbol)
        {

            ticTacToeSpaces[5].onClick.Invoke();
        }
        else if (_board_._board[2, 0] == simbol)
        {

            ticTacToeSpaces[6].onClick.Invoke();
        }
        else if (_board_._board[2, 1] == simbol)
        {

            ticTacToeSpaces[7].onClick.Invoke();
        }
        else if (_board_._board[2, 2] == simbol)
        {

            ticTacToeSpaces[8].onClick.Invoke();
        }
    }
}

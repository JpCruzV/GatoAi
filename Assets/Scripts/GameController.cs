using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int turn;
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;
    public Button[] ticTacToeSpaces;
    public int[] markedSpaces;


    private void Start() {

        GameSetUp();
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

        for (int i = 0; i < markedSpaces.Length; i++) {

            markedSpaces[i] = -99;
        }
    }


    public void TicTacToeBtn(int btn) {

        ticTacToeSpaces[btn].image.sprite = playerIcons[turn];
        ticTacToeSpaces[btn].interactable = false;

        markedSpaces[btn] = turn + 1;
        turnCount++;

        if (turnCount > 4) {

            WinnerCheck();
        }

        if (turn == 0) {

            turn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else {

            turn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }


    void WinnerCheck() {

        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];

        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];

        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];

        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };

        for (int i = 0; i < solutions.Length; i++) {

            if ( solutions[i] == 3 * (turn + 1) ) {

                Debug.Log("Player " + (turn + 1) + " Won!");
                return;
            }
        }
    }
}

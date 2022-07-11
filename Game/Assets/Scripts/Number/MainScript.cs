using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public GameObject startGameScene;
    public GameObject gameScene;
    public GameObject guessYourNumberSelection;

    public int maxNumber = 10;

    public int numberToGuess;
    public int player1Number;
    public int yourNumber;

    public void StartGame()
    {
        Debug.Log("StartGame");
        startGameScene.SetActive(false);
        numberToGuess = Random.Range(1, maxNumber);
        player1Number = Random.Range(1, maxNumber);
        GuessYoureNumber();
    }

    public void GuessYoureNumber()
    {
        gameScene.SetActive(false);
        guessYourNumberSelection.SetActive(true);
    }

    void CloseYourNumberGuess()
    {
        gameScene.SetActive(true);
        guessYourNumberSelection.SetActive(false);
    }

    public void PlayAgain()
    {

    }

    public void GuessNumber(int num)
    {
        yourNumber = num;
        CloseYourNumberGuess();
    }
}

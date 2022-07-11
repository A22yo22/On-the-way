using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    //references to all Game Scenes
    public GameObject startGameScene;
    public GameObject gameScene;
    public GameObject guessYourNumberSelection;

    public Game gameScript;


    //Starts the game
    public void StartGame()
    {
        startGameScene.SetActive(false);
        gameScene.SetActive(true);

        StartCoroutine(gameScript.GenerateNumberToGuess());
    }

    //opens the num menue
    public void GuessYoureNumber()
    {
        gameScene.SetActive(false);
        guessYourNumberSelection.SetActive(true);
    }

    //Gets the number you pressed in the num menue
    public void GuessNumber(int num)
    {
        gameScript.yourNumber = num;
        gameScene.SetActive(true);
        guessYourNumberSelection.SetActive(false);
    }
}

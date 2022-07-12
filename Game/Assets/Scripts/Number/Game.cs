using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    //references to loadScreens
    public GameObject guessNumberLoading;
    public GameObject player1GuessingNumber;


    public GameObject playAgain;


    //reference to all Generated Number texts
    //Text your text field for youre number
    public TMP_Text guessedNumberText;
    public TMP_Text player1GuessedNumberText;
    public TMP_Text yourNumberText;

    //The highest number you can pick
    public int maxNumber = 10;

    //Guessed Numbers
    public int numberToGuess;
    public int player1Number;
    public int yourNumber;

    public MainScript mainScript;

    public IEnumerator GenerateNumberToGuess()
    {
        guessNumberLoading.SetActive(true);
        yield return new WaitForSeconds(3);
        guessNumberLoading.SetActive(false);
        numberToGuess = Random.Range(1, maxNumber);
        guessedNumberText.transform.gameObject.SetActive(true);

        StartCoroutine(Player1GuessingNumber());
    }

    public IEnumerator Player1GuessingNumber()
    {
        player1GuessingNumber.SetActive(true);
        yield return new WaitForSeconds(3);
        player1GuessingNumber.SetActive(false);
        player1Number = Random.Range(1, maxNumber);
        player1GuessedNumberText.transform.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        mainScript.GuessYoureNumber();
    }

    public void NumberPicked()
    {
        guessedNumberText.text = numberToGuess.ToString();
        player1GuessedNumberText.text = player1Number.ToString();
        yourNumberText.text = yourNumber.ToString();

        CalculateResult();

        playAgain.SetActive(true);
    }

    void CalculateResult()
    {
        int resultPlayer1 = numberToGuess - player1Number;
        int resultYou = numberToGuess - yourNumber;

        bool youWin;
        if ( resultPlayer1 < 0 || resultYou < 0)
        {
            youWin = resultYou > resultPlayer1;
        } else
        {
            youWin = resultYou < resultPlayer1;
        }

        Debug.Log($"You = {resultYou} \n Player1 = {resultPlayer1}");
        Debug.Log($"You Win = {youWin}");
        if(resultPlayer1 == resultYou) { Debug.Log("draw"); }
    }

    public void PlayAgain()
    {
        numberToGuess = 0;
        player1Number = 0;
        yourNumber = 0;

        guessedNumberText.text = "???";
        player1GuessedNumberText.text = "???";
        yourNumberText.text = "";

        mainScript.startGameScene.SetActive(true);
        mainScript.gameScene.SetActive(false);
        playAgain.SetActive(false);
    }
}

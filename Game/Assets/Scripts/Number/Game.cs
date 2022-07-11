using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    //references to loadScreens
    public GameObject guessNumberLoading;
    public GameObject player1GuessingNumber;

    //reference to all Generated Number texts
    public GameObject guessedNumberText;
    public GameObject player1GuessedNumberText;
    public TMP_Text yourNumberText;

    //The highest number you can pick
    public int maxNumber = 10;

    //Guessed Numbers
    public int numberToGuess;
    public int player1Number;
    public int yourNumber;

    public bool youreNumberGussed = false;

    public MainScript mainScript;

    public IEnumerator GenerateNumberToGuess()
    {
        guessNumberLoading.SetActive(true);
        yield return new WaitForSeconds(3);
        guessNumberLoading.SetActive(false);
        numberToGuess = Random.Range(1, maxNumber);
        guessedNumberText.SetActive(true);

        StartCoroutine(Player1GuessingNumber());
    }

    public IEnumerator Player1GuessingNumber()
    {
        player1GuessingNumber.SetActive(true);
        yield return new WaitForSeconds(3);
        player1GuessingNumber.SetActive(false);
        player1Number = Random.Range(1, maxNumber);
        player1GuessedNumberText.SetActive(true);

        yield return new WaitForSeconds(1);

        mainScript.GuessYoureNumber();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    //references to loadScreens
    public GameObject guessNumberLoading;
    public GameObject player1GuessingNumber;

    //RoundOver references
    public GameObject roundOver;

    public TMP_Text roundOverWonOrLostText;
    public TMP_Text roundOverNumberToGuessText;
    public TMP_Text roundOverPlayer1NumberGuessedText;
    public TMP_Text roundOverYourNumberGuessedText;

    public TMP_Text roundOverMoneyMade;


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

    public bool youWin = false;
    public bool draw = false;

    public MainScript mainScript;
    public Money moneyManager;

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

        roundOver.SetActive(true);
    }

    void CalculateResult()
    {
        int resultPlayer1 = numberToGuess - player1Number;
        int resultYou = numberToGuess - yourNumber;

        
        if ( resultPlayer1 < 0 || resultYou < 0)
        {
            youWin = resultYou > resultPlayer1;
        } else
        {
            youWin = resultYou < resultPlayer1;
        }

        if(resultPlayer1 == resultYou) { draw = true; }

        RoundOverControll();
    }

    public void RoundOverControll()
    {
        if (draw) { roundOverWonOrLostText.text = "It?s a draw"; } 
        else if (youWin && !draw) { roundOverWonOrLostText.text = "You won"; } 
        else if (!youWin && !draw) { roundOverWonOrLostText.text = "You lost"; }

        roundOverNumberToGuessText.text = numberToGuess.ToString();
        roundOverYourNumberGuessedText.text = yourNumber.ToString();
        roundOverPlayer1NumberGuessedText.text = player1Number.ToString();

        roundOverMoneyMade.text = CalculateMoneyMade(yourNumber, numberToGuess, youWin, draw).ToString();
        moneyManager.AddMoney(CalculateMoneyMade(yourNumber, numberToGuess, youWin, draw));
    }

    public int CalculateMoneyMade(int yourNum, int neededToGuess, bool roundWon, bool drawMode)
    {
        if(roundWon && !drawMode)
        {
            int resultYou = neededToGuess - yourNum;
            switch (resultYou)
            {
                case 0: return 500;

                case 1: return 450;
                case -1: return 450;

                case 2: return 400;
                case -2: return 400;

                case 3: return 300;
                case -3: return 300;

                case 4: return 200;
                case -4: return 200;

                case 5: return 150;
                case -5: return 150;

                case 6: return 100;
                case -6: return 100;

                default: return 0;
            }
        }else { return 0; }
    }

    public void PlayAgain()
    {
        numberToGuess = 0;
        player1Number = 0;
        yourNumber = 0;

        youWin = false;
        draw = false;

        guessedNumberText.text = "???";
        player1GuessedNumberText.text = "???";
        guessedNumberText.gameObject.SetActive(false);
        player1GuessedNumberText.gameObject.SetActive(false);
        yourNumberText.text = "";

        mainScript.startGameScene.SetActive(true);
        mainScript.gameScene.SetActive(false);
        roundOver.SetActive(false);
    }
}

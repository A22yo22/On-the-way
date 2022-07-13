using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public int money;
    public int current;
    public int best;

    //Text
    public TMP_Text currentText;
    public TMP_Text bestText;
    public TMP_Text moneyText;

    public Money moneyManager;

    public void TilePlaced()
    {
        current += 1;
    }

    public void GameOver()
    {
        if (current >= best)
        {
            best = current;
        }

        money = current * 10;

        SaveGame();

        currentText.text = current.ToString();
        bestText.text = best.ToString();
        moneyText.text = money.ToString();
        moneyManager.AddMoney(money);

    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("best", best);
    }

    public void LoadGame()
    {
        best = PlayerPrefs.GetInt("best");
    }
}

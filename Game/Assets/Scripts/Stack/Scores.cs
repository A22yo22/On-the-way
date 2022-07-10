using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public int money;
    public int currentTime;
    public int bestTime;

    public bool playTimer = false;

    //Text
    public TMP_Text currentTimeText;
    public TMP_Text bestTimeText;
    public TMP_Text moneyText;

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);

        currentTime++;
        if (playTimer)
        {
            StartCoroutine(Timer());
        }
    }

    public void GameOver()
    {
        playTimer = false;

        if (currentTime >= bestTime)
        {
            bestTime = currentTime;
        }

        money = currentTime * 10;

        SaveGame();

        currentTimeText.text = currentTime.ToString();
        bestTimeText.text = bestTime.ToString();
        moneyText.text = money.ToString();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("bestTime", bestTime);
    }

    public void LoadGame()
    {
        money = PlayerPrefs.GetInt("money");
        bestTime = PlayerPrefs.GetInt("bestTime");
    }
}

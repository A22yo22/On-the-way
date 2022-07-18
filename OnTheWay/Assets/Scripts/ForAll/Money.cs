using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int money = 0;

    private void Awake()
    {
        money = loadMoney();
    }

    public int loadMoney()
    {
        return PlayerPrefs.GetInt("money");
    }

    public void AddMoney(int amount)
    {
        PlayerPrefs.SetInt("money", money + amount);
        money = loadMoney();
    }

    public void DivideMoney(int amount)
    {
        PlayerPrefs.SetInt("money", money - amount);
        money = loadMoney();
    }

    public void ClearMoney()
    {
        PlayerPrefs.SetInt("money", 0);
    }

    public void Refresh(TMP_Text text)
    {
        text.text = loadMoney().ToString();
    }
}

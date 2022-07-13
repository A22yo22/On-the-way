using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    int money = 0;

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
}

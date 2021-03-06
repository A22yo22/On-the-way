using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenueHadler : MonoBehaviour
{
    //reference to Scripts
    public BuyShit buyShitScript;

    //reference to the main menu tabs
    public GameObject mainMenue;
    public GameObject gamesTab;
    public GameObject shopTab;
    public GameObject statsTab;

    //money setup
    public TMP_Text moneyText;
    public Money moneyManager;

    //opes the main menue and sets all other tabs to unvisable
    public void OpenMainMenue()
    {
        mainMenue.SetActive(true);
        gamesTab.SetActive(false);
        shopTab.SetActive(false);
        statsTab.SetActive(false);
    }

    //opens the games tab
    public void OpenGamesTab()
    {
        gamesTab.SetActive(true);
        mainMenue.SetActive(false);
    }

    //opens the shop tab
    public void OpenShopTab()
    {
        moneyText.text = $"Money = {moneyManager.loadMoney()}";
        buyShitScript.LoadStackShop();
        shopTab.SetActive(true);
        mainMenue.SetActive(false);
    }

    //opens the static tab 
    public void OpenStatsTab()
    {
        statsTab.SetActive(true);
        mainMenue.SetActive(false);
    }




    //open games
    public void OpenStackGame()
    {
        SceneManager.LoadScene("Stack");
    }

    public void OpenNumber()
    {
        SceneManager.LoadScene("Number");
    }
}

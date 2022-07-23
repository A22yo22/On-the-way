using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyShit : MonoBehaviour
{
    // 0 = Red, 1 = Blue, 2 = Yellow, 3 = Broun, 4 = Pink, 5 = Orange
    public List<TMP_Text> itemsColorTextBoughtOrNotStack;
    public List<TMP_Text> itemsTextureTextBoughtOrNotStack;
    public List<GameObject> itemSelectedColorStack;
    public List<GameObject> itemSelectedTextureStack;
    public List<GameObject> stackSelectItemColor;
    public List<GameObject> stackSelectItemTexture;

    public int itemsBoughtStackLength = 0;

    public TMP_Text moneyText;

    //referce to the Shop scriptable objects
    public StackSkins stackSkinsSOBJ;

    //reference to scripts
    public Money moneyScript;

    private void Start()
    {
        moneyScript.AddMoney(10000);
    }

    public void BuyItemColorStack(int id)
    {
        if (moneyScript.loadMoney() >= 100)
        {
            moneyScript.DivideMoney(100);
            moneyScript.Refresh(moneyText);

            PlayerPrefs.SetInt($"itemsBoughtStack{itemsBoughtStackLength}", id);
            itemsBoughtStackLength++;

            for (int i = 0; i < itemSelectedColorStack.Count; i++)
            {
                itemSelectedColorStack[i].SetActive(false);
            }
            for (int i = 0; i < itemSelectedTextureStack.Count; i++)
            {
                itemSelectedTextureStack[i].SetActive(false);
            }

            itemSelectedColorStack[id].SetActive(true);
            itemsColorTextBoughtOrNotStack[id].text = "sold";
            itemSelectedColorStack[id].transform.parent.gameObject.GetComponent<Button>().enabled = false;

            stackSelectItemColor[id].SetActive(true);

            PlayerPrefs.SetInt("itemsBoughtStackLength", itemsBoughtStackLength);
            PlayerPrefs.SetInt("StackPlayerColorSkinSelected", id);
            stackSkinsSOBJ.coloredSkinSelected = true;
        }
    }

    public void BuyItemTextureStack(int id)
    {
        if (moneyScript.loadMoney() >= 1000)
        {
            moneyScript.DivideMoney(1000);
            moneyScript.Refresh(moneyText);

            PlayerPrefs.SetInt($"itemsBoughtStack{itemsBoughtStackLength}", id);
            itemsBoughtStackLength++;

            for (int i = 0; i < itemSelectedColorStack.Count; i++)
            {
                itemSelectedColorStack[i].SetActive(false);
            }
            for (int i = 0; i < itemSelectedTextureStack.Count; i++)
            {
                itemSelectedTextureStack[i].SetActive(false);
            }

            itemSelectedTextureStack[id].SetActive(true);
            itemsTextureTextBoughtOrNotStack[id].text = "sold";
            itemSelectedTextureStack[id].transform.parent.gameObject.GetComponent<Button>().enabled = false;

            stackSelectItemColor[id].SetActive(true);

            PlayerPrefs.SetInt("itemsBoughtStackLength", itemsBoughtStackLength);
            PlayerPrefs.SetInt("StackPlayerTextureSkinSelected", id);
            stackSkinsSOBJ.coloredSkinSelected = false;
        }
    }

    public void LoadStackShop()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("itemsBoughtStackLength"); i++)
        {
            int itemBoughtStackNumber = PlayerPrefs.GetInt($"itemsBoughtStack{i}");

            if (stackSkinsSOBJ.coloredSkinSelected)
            {
                for (int y = 0; y < itemSelectedColorStack.Count; y++)
                {
                    itemSelectedColorStack[y].SetActive(false);
                }
                for (int y = 0; y < itemSelectedTextureStack.Count; y++)
                {
                    itemSelectedTextureStack[y].SetActive(false);
                }

                itemSelectedColorStack[PlayerPrefs.GetInt("StackPlayerColorSkinSelected")].SetActive(true);

                itemSelectedColorStack[itemBoughtStackNumber].transform.parent.gameObject.GetComponent<Button>().enabled = false;
                itemsColorTextBoughtOrNotStack[itemBoughtStackNumber].text = "sold";

                stackSelectItemColor[itemBoughtStackNumber].SetActive(true);
            } 
            else
            {
                for (int y = 0; y < itemSelectedTextureStack.Count; y++)
                {
                    itemSelectedTextureStack[y].SetActive(false);
                }

                itemSelectedTextureStack[PlayerPrefs.GetInt("StackPlayerTextureSkinSelected")].SetActive(true);

                itemSelectedTextureStack[itemBoughtStackNumber].transform.parent.gameObject.GetComponent<Button>().enabled = false;
                itemsColorTextBoughtOrNotStack[itemBoughtStackNumber].text = "sold";

                stackSelectItemColor[itemBoughtStackNumber].SetActive(true);
            }
            
        }
    }

    public void SelectItemStack(int id)
    {
        if (stackSkinsSOBJ.coloredSkinSelected)
        {
            for (int i = 0; i < itemSelectedColorStack.Count; i++)
            {
                itemSelectedColorStack[i].SetActive(false);
            }

            itemSelectedColorStack[id].SetActive(true);
            PlayerPrefs.SetInt("StackPlayerColorSkinSelected", id);
        }
        else
        {
            for (int i = 0; i < itemSelectedTextureStack.Count; i++)
            {
                itemSelectedTextureStack[i].SetActive(false);
            }

            itemSelectedTextureStack[id].SetActive(true);
            PlayerPrefs.SetInt("StackPlayerTextureSkinSelected", id);
        }

    }
}

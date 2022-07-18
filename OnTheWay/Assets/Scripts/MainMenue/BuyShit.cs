using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyShit : MonoBehaviour
{
    // 0 = Red, 1 = Blue, 2 = Yellow, 3 = Broun, 4 = Pink, 5 = Orange
    public List<TMP_Text> itemsTextBoughtOrNotStack;
    public List<GameObject> itemSelectedStack;
    public List<GameObject> stackSelectItem;

    public int itemsBoughtStackLength = 0;

    private void Start()
    {

    }

    public void BuyItemStack(int id, Color itemColor)
    {
        PlayerPrefs.SetInt($"itemsBoughtStack{itemsBoughtStackLength}", id);
        itemsBoughtStackLength++;

        for (int i = 0; i < itemSelectedStack.Count; i++)
        {
            itemSelectedStack[i].SetActive(false);
        }

        itemSelectedStack[id].SetActive(true);
        itemsTextBoughtOrNotStack[id].text = "sold";
        itemSelectedStack[id].transform.parent.gameObject.GetComponent<Button>().enabled = false;

        PlayerPrefs.SetInt("itemsBoughtStackLength", itemsBoughtStackLength);
        PlayerPrefs.SetInt("StackPlayerSkinSelected", id);
    }

    public void LoadStackShop()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("itemsBoughtStackLength"); i++)
        {
            int itemBoughtStackNumber = PlayerPrefs.GetInt($"itemsBoughtStack{i}");

            for (int y = 0; y < itemSelectedStack.Count; y++)
            {
                itemSelectedStack[y].SetActive(false);
            }

            itemSelectedStack[PlayerPrefs.GetInt("StackPlayerSkinSelected")].SetActive(true);

            itemSelectedStack[itemBoughtStackNumber].transform.parent.gameObject.GetComponent<Button>().enabled = false;
            itemsTextBoughtOrNotStack[itemBoughtStackNumber].text = "sold";
        }
    }

    public void SelectItemStack(int id)
    {
        for (int i = 0; i < itemSelectedStack.Count; i++)
        {
            itemSelectedStack[i].SetActive(false);
        }

        itemSelectedStack[id].SetActive(true);

        PlayerPrefs.SetInt("StackPlayerSkinSelected", id);
    }
}

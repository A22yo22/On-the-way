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

    public int itemsBoughtLength = 0;

    private void Start()
    {
        for (int i = 0; i < itemSelectedStack.Count; i++)
        {
            PlayerPrefs.GetInt($"itemsBoughtStack{i}");
        }
    }

    public void BuyItemStack(int id)
    {
        PlayerPrefs.SetInt($"itemsBoughtStack{itemsBoughtLength}", id);
        itemsBoughtLength++;

        for (int i = 0; i < itemSelectedStack.Count; i++)
        {
            itemSelectedStack[i].SetActive(false);
        }

        itemSelectedStack[id].SetActive(true);
        itemsTextBoughtOrNotStack[id].text = "sold";
        itemSelectedStack[id].transform.parent.gameObject.GetComponent<Button>().enabled = false;
    }
}

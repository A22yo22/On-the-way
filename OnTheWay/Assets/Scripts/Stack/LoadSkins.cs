using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadSkins : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public StackSkins stackSkinsObject;

    void Start()
    {
        if(stackSkinsObject.coloredSkinSelected)
        {
            Player1.GetComponent<SpriteRenderer>().color = stackSkinsObject.playerSkinColors[PlayerPrefs.GetInt("StackPlayerColorSkinSelected")];
            Player2.GetComponent<SpriteRenderer>().color = stackSkinsObject.playerSkinColors[PlayerPrefs.GetInt("StackPlayerColorSkinSelected")];
            Player1.transform.localScale = new Vector3(1f, 0.6f, 1f);
            Player2.transform.localScale = new Vector3(1f, 0.6f, 1f);
        }
        else
        {
            Player1.GetComponent<SpriteRenderer>().sprite = stackSkinsObject.playerSkinTextures[PlayerPrefs.GetInt("StackPlayerTextureSkinSelected")];
            Player2.GetComponent<SpriteRenderer>().sprite = stackSkinsObject.playerSkinTextures[PlayerPrefs.GetInt("StackPlayerTextureSkinSelected")];
            Player1.transform.localScale = new Vector3(0.095f, 0.12f, 1f);
            Player2.transform.localScale = new Vector3(0.095f, 0.12f, 1f);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadSkins : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public List<Color> playerSkinColors;

    void Start()
    {
        Player1.GetComponent<SpriteRenderer>().color = playerSkinColors[PlayerPrefs.GetInt("StackPlayerSkinSelected")];
        Player2.GetComponent<SpriteRenderer>().color = playerSkinColors[PlayerPrefs.GetInt("StackPlayerSkinSelected")];
    }
}

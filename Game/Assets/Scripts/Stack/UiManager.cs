using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public SpawnWood spawnWoodScript;

    public GameObject gameOverScreen;

    public void PlayAgain()
    {
        spawnWoodScript.ClearGame();
        spawnWoodScript.gameOver = false;

        gameOverScreen.SetActive(false);
    }
}

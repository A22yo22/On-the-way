using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public SpawnWood spawnWoodScript;

    public GameObject gameOverScreen;

    public Scores scoreScript;

    public void PlayAgain()
    {
        spawnWoodScript.ClearGame();
        scoreScript.current = 0;
        spawnWoodScript.gameOver = false;

        gameOverScreen.SetActive(false);

        spawnWoodScript.scoreText.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endScreen;

    public SpawnWood spawnWoodScript;
    public Scores scoresScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        endScreen.SetActive(true);

        spawnWoodScript.ClearGame();

        scoresScript.GameOver();

        spawnWoodScript.gameOver = true;
    }
}

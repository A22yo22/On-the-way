using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWood : MonoBehaviour
{
    public GameObject wood;
    public GameObject cam;

    public TMPro.TMP_Text scoreText;

    public bool woodSpawned = false;
    bool waitingFinished = false;

    Vector2 velocetyForWood = new Vector2(2f, 0);
    public float spawnPos = 1;

    public List<GameObject> woodObject;

    public int woodListCounterPos = -1;

    public Scores scoresScript;

    public int gameStarted = 0;

    public bool gameOver = false;
    public bool tuchedGround = false;

    void Update()
    {
        if (!woodSpawned && !gameOver)
        {
            if (gameStarted >= 1)
            {
                if (tuchedGround)
                {
                    tuchedGround = false;
                    waitingFinished = false;
                    woodSpawned = true;

                    woodListCounterPos++;

                    WaitToSpawnWood();
                }
            } 
            else 
            {
                waitingFinished = false;
                woodSpawned = true;

                woodListCounterPos++; 
                WaitToSpawnWood(); 
            }
        }

        if(woodSpawned && waitingFinished && !gameOver)
        {
            if (woodObject[woodListCounterPos].transform.position.x >= 2.25f)
            {
                velocetyForWood = new Vector2(-2.25f, 0);
            }
            else if (woodObject[woodListCounterPos].transform.position.x <= -2.25f)
            {
                velocetyForWood = new Vector2(2.25f, 0);
            }

            woodObject[woodListCounterPos].GetComponent<Rigidbody2D>().velocity = velocetyForWood;
        }

        if (Input.GetMouseButtonDown(0) && woodSpawned && waitingFinished && !gameOver)
        {
            scoresScript.TilePlaced();
            scoreText.text = scoresScript.current.ToString();

            woodSpawned = false;
            gameStarted++;

            spawnPos += 0.6f;
            cam.transform.position = new Vector3(0, cam.transform.position.y + 0.6f, -10f);

            if(gameStarted == 1)
            {
                scoresScript.LoadGame();
            }

            Rigidbody2D rb = woodObject[woodListCounterPos].GetComponent<Rigidbody2D>();
            rb.velocity = velocetyForWood = Vector2.zero;
            rb.gravityScale = 1;
        }
    }

    public void WaitToSpawnWood()
    {
        woodObject.Add(Instantiate(wood));
        woodObject[woodListCounterPos].GetComponent<WoodEnter>().spawnWoodScript = this;

        Rigidbody2D rb = woodObject[woodListCounterPos].AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.transform.position = new Vector2(0, spawnPos);

        velocetyForWood = new Vector2(2f, 0);

        waitingFinished = true;
    }

    public void ClearGame()
    {
        for(int i=0; i < woodObject.Count; i++)
        {
            Destroy(woodObject[i]);
        }

        woodObject.RemoveRange(0, woodObject.Count);

        woodListCounterPos = -1;
        gameStarted = 0;
        woodSpawned = false;
        tuchedGround = false;
        scoreText.text = "0";

        cam.transform.position = new Vector3(0f, 0f, -10f);
        spawnPos = 1;
    }
}

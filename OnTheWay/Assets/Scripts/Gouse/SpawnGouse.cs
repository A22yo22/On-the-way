using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGouse : MonoBehaviour
{
    public GameObject goosePrefab;

    void Start()
    {
        SpawnGooseFunc();
        SpawnGooseFunc();
        SpawnGooseFunc();
        SpawnGooseFunc();
        SpawnGooseFunc();
    }

    public void SpawnGooseFunc()
    {
        GameObject x = Instantiate(goosePrefab);
        x.AddComponent<Rigidbody2D>().gravityScale = 0;
        Rigidbody2D rb = x.GetComponent<Rigidbody2D>();

        Vector2 spawnpos = new Vector2();
        if(Random.Range(1, 3) == 2)
        {
            spawnpos = new Vector2(-7f, Random.Range(4, -2));
            rb.velocity = new Vector2(1, 0);
        } 
        else 
        { 
            spawnpos = new Vector2(7f, Random.Range(4, -2));
            rb.velocity = new Vector2(-1, 0);
        }

        x.transform.position = spawnpos;
    }
}

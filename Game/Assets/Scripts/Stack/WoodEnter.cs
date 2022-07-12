using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodEnter : MonoBehaviour
{
    public SpawnWood spawnWoodScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spawnWoodScript.tuchedGround = true;
        this.enabled = false;
        Destroy(gameObject.GetComponent<WoodEnter>());
    }
}

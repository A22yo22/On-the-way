using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 1) * 2.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.velocity = transform.position.normalized - collision.transform.position.normalized * 4f;
    }
}

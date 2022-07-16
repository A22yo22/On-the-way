using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBallTest : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Debug.Log(transform.position - explosion.transform.position);

        rb.AddForce(transform.position - explosion.transform.position * 5, ForceMode2D.Impulse);
    }
}

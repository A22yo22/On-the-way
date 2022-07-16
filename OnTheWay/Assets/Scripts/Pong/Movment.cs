using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(8.5f, transform.position.y + 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(8.5f, transform.position.y - 0.5f);
        }
    }
}

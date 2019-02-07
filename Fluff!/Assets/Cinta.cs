using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinta : MonoBehaviour
{
    float fuerza = 200f;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            Debug.Log("ok");
            col.GetComponent<Rigidbody2D>().AddForce(Vector2.left * fuerza);
        }
    }
}

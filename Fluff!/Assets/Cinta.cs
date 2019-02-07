using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinta : MonoBehaviour
{
    public float fuerza = 0f;
    public Vector2 direccion = Vector2.left;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            col.GetComponent<Rigidbody2D>().AddForce(direccion * fuerza);
        }
    }
}

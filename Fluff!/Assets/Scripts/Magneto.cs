using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magneto : MonoBehaviour
{
    Rigidbody2D rb;

    public float fuerzaAtraccion = 5f;
    public Vector2 direccion = Vector2.left;
    bool atraeDerecha = false;
    bool atraeIzquierda = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            col.transform.position = transform.position;
            col.GetComponent<Rigidbody2D>().velocity = -(direccion * fuerzaAtraccion);
        }
    }
}


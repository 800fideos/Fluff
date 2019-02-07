using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody2D rb;

    public float fuerza_movimiento = 500f;
    Vector2 vector_inicio;
    Vector2 vector_fin;
    Vector2 resta_vector;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    
    }

    private void OnMouseDown()
    {
        if (Input.touchCount > 0)
        {
            vector_inicio = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
        {
            vector_inicio = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if (Input.touchCount > 0)
        {
            vector_fin = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            CalculaVector();
        }
        else
        {
            vector_fin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CalculaVector();
        }
        
    }

    void CalculaVector()
    {
        resta_vector = vector_fin - vector_inicio;
        if (Mathf.Abs(resta_vector.y) > Mathf.Abs(resta_vector.x))
        {
            if (resta_vector.y > 0)
            {
                rb.AddForce(Vector2.up * fuerza_movimiento);
            }
            else
            {
                rb.AddForce(Vector2.up * -fuerza_movimiento);
            }
        }
        if (Mathf.Abs(resta_vector.y) < Mathf.Abs(resta_vector.x))
        {
            if (resta_vector.x > 0)
            {
                rb.AddForce(Vector2.right * fuerza_movimiento);
            }
            else
            {
                rb.AddForce(Vector2.right * -fuerza_movimiento);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
        //if (col.gameObject.CompareTag("Limite"))
        //{
            //Destroy(gameObject);
        //}
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magneto : MonoBehaviour
{
    Rigidbody2D rb;

    public float fuerzaAtraccion = 5f;
    bool atraeDerecha = false;
    bool atraeIzquierda = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        LanzarRaycast();
    }

    private void AtraerPelusa()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            if (atraeDerecha)
            {
                rb.velocity = (Vector2.left * fuerzaAtraccion);
            }
            if (atraeIzquierda)
            {
                rb.velocity = (Vector2.right * fuerzaAtraccion);
            }  
        }
    }

    private void LanzarRaycast()
    {
        RaycastHit2D hitDerecha = Physics2D.Raycast(new Vector2 (transform.position.x + gameObject.GetComponent<Collider2D>().bounds.size.x / 2 + 0.1f, transform.position.y), Vector2.right);
        RaycastHit2D hitIzquierda = Physics2D.Raycast(new Vector2 (-(transform.position.x + gameObject.GetComponent<Collider2D>().bounds.size.x / 2 + 0.1f), transform.position.y), Vector2.left);

        //Debug.DrawRay(position, direction, Color.blue);
        
        if (hitDerecha.collider != null)
        {
            atraeDerecha = true;
            AtraerPelusa();
        }
        if (hitIzquierda.collider != null)
        {
            atraeIzquierda = true;
            AtraerPelusa();
        }
    }
}


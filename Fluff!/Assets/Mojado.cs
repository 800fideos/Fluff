using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mojado : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject charcoPrefab;
    GameObject charcoNuevo;
    public Vector3 posicionSiguienteCharco;

    
    float velocidadActual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionSiguienteCharco = transform.position;
    }

    void Update()
    {
        velocidadActual = rb.velocity.magnitude;
        Debug.Log(velocidadActual);
        if (velocidadActual > 1f && transform.position == posicionSiguienteCharco);
        {
            RastroAgua();
        }
    }

    void RastroAgua()
    {
        Debug.Log("Creando Charco");
        
        if (rb.velocity.x > 0f)
        {
            charcoNuevo = Instantiate(charcoPrefab, transform.position, transform.rotation);
            posicionSiguienteCharco = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (rb.velocity.x < 0f)
        {
            charcoNuevo = Instantiate(charcoPrefab, transform.position, transform.rotation);
            posicionSiguienteCharco = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if(rb.velocity.y > 0f)
        {
            charcoNuevo = Instantiate(charcoPrefab, transform.position, transform.rotation);
            posicionSiguienteCharco = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
        if (rb.velocity.y < 0f)
        {
            charcoNuevo = Instantiate(charcoPrefab, transform.position, transform.rotation);
            posicionSiguienteCharco = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
    }
}

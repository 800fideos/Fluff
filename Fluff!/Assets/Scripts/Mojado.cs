using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mojado : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject charcoPrefab;
    GameObject charcoNuevo;
    public Vector3 posicionSiguienteCharco;
    Vector3 posicionInicial;
    public bool primerCharco = true;

    
    public float velocidadActual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionSiguienteCharco = transform.position;
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (rb != null)
            velocidadActual = rb.velocity.magnitude;
       
        if (velocidadActual > 1f)
        {
            if (primerCharco)
            {
                Debug.Log(velocidadActual);
                SoltarCharco(new Vector3(transform.position.x, transform.position.y, -0.5f), Vector3.zero);
                primerCharco = false;
            }

            if (rb != null)
                RastroAgua();
        }
        else
        {
            primerCharco = true;
        }
    }

    void RastroAgua()
    {
        Debug.Log("Creando Charco");
        Vector3 posicionCharco = new Vector3(transform.position.x, transform.position.y, - 0.5f);
        if (rb.velocity.x > 0f && transform.position.x > posicionInicial.x + 2f)
        {
            SoltarCharco(posicionCharco, Vector3.zero);
            posicionInicial = posicionCharco;
        }
        if (rb.velocity.x < 0f && transform.position.x < posicionInicial.x - 2f)
        {
            SoltarCharco(posicionCharco, Vector3.zero);
            posicionInicial = posicionCharco;
        }
        if(rb.velocity.y > 0f && transform.position.y > posicionInicial.y + 2f)
        {
            SoltarCharco(posicionCharco, new Vector3(0, 0, 90));
            posicionInicial = posicionCharco;
        }
        if (rb.velocity.y < 0f && transform.position.y < posicionInicial.y - 2f)
        {
            SoltarCharco(posicionCharco, new Vector3(0, 0, 90));
            posicionInicial = posicionCharco;
        }
    }

    void SoltarCharco(Vector3 posicion, Vector3 rotacion)
    {
        charcoNuevo = Instantiate(charcoPrefab, posicion, transform.rotation);
        charcoNuevo.transform.Rotate(rotacion);
        charcoNuevo.GetComponent<ParaPelusas>().SetPadre(gameObject);
    }

}

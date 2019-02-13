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
        velocidadActual = rb.velocity.magnitude;
       
        if (velocidadActual > 1f)
        {
            if (primerCharco)
            {
                Debug.Log(velocidadActual);
                charcoNuevo = Instantiate(charcoPrefab, new Vector3(transform.position.x,transform.position.y, -0.5f), transform.rotation);
                primerCharco = false;
            }
            RastroAgua();
        }
    }

    void RastroAgua()
    {
        Debug.Log("Creando Charco");
        Vector3 posicionCharco = new Vector3(transform.position.x, transform.position.y, - 0.5f);
        if (rb.velocity.x > 0f && transform.position.x > posicionInicial.x + 1.5f)
        {
            charcoNuevo = Instantiate(charcoPrefab, posicionCharco, transform.rotation);
            //posicionSiguienteCharco = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            posicionInicial = posicionCharco;
        }
        if (rb.velocity.x < 0f && transform.position.x < posicionInicial.x - 1.5f)
        {
            charcoNuevo = Instantiate(charcoPrefab, posicionCharco, transform.rotation);
            //posicionSiguienteCharco = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            posicionInicial = posicionCharco;
        }
        if(rb.velocity.y > 0f && transform.position.y > posicionInicial.y + 1.5f)
        {
            charcoNuevo = Instantiate(charcoPrefab, posicionCharco, transform.rotation);
            charcoNuevo.transform.Rotate(new Vector3(0, 90, 0));
            //posicionSiguienteCharco = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            posicionInicial = posicionCharco;
        }
        if (rb.velocity.y < 0f && transform.position.y < posicionInicial.y - 1.5f)
        {
            charcoNuevo = Instantiate(charcoPrefab, transform.position, transform.rotation);
            charcoNuevo.transform.Rotate(new Vector3 (0,90,0));
            //posicionSiguienteCharco = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            posicionInicial = posicionCharco;
        }
    }
}

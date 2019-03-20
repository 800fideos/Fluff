/* Mojado.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Monchburg (Ramón González)
 * Comentado por @Monchburg (Ramón González)
 * Script que controla la habilidad especial del personaje mojado. 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mojado : MonoBehaviour
{
    // Creación de las variables necesarias para el personaje mojado.
    Rigidbody2D rb; // Creación del rigidbody. 

    public GameObject charcoPrefab; // Variable en la cual introduciremos el prefab del charco. 
    GameObject charcoNuevo; // Variable que almacenará un nuevo charco. 
    public Vector3 posicionSiguienteCharco; // Vector que almacenará la posición del charco. 
    Vector3 posicionInicial; // Vector que almacena la posición donde se encuentra la pelusa en principio.  
    public bool primerCharco = true; // Variable que controla si la pelusa tiene que soltar el primer charco. 

    
    public float velocidadActual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        posicionSiguienteCharco = transform.position; // Iguala la posición del siguiente charco a la posición que tenga la pelusa.
        posicionInicial = transform.position; // Iguala la posición inical a la posición que tenga la pelusa.
    }

    void Update()
    {

        if (rb != null) // Si el personaje tiene rigidbody...
            velocidadActual = rb.velocity.magnitude; // Igualamos la variable velocidadActual a la velocidad que tenga la pelusa.
       
        if (velocidadActual > 1f) // Si la velocidad es mayor que 1...
        {
            if (primerCharco) // Si además la pelusa puede soltar el primer charco...
            {
                SoltarCharco(new Vector3(transform.position.x, transform.position.y, -0.5f), Vector3.zero); // Llama a la función que suelta charcos y le da la posición en la que tiene que soltarlo.
                primerCharco = false; // Desactiva la posibilidad de soltar el primer charco.
            }

            if (rb != null) // Si el personaje tiene rigidbody...
                RastroAgua(); // Llama a la función que suelta el rastro de charcos. 
        }
        else
        {
            primerCharco = true; // Esto es una confirmación para que suelte el primer charco. 
        }
    }

    // Función que controla el rastro de charcos que suelta la pelusa.
    void RastroAgua()
    {
        Vector3 posicionCharco = new Vector3(transform.position.x, transform.position.y, - 0.5f); // Inicializa la variable de posición del charco.
        if (rb.velocity.x > 0f && transform.position.x > posicionInicial.x + 2f) // Si la pelusa tiene velocidad y la posición en el eje X es la posición inicial más 2 unidades hacia la derecha 
                                                                                 // (posición incial y otra más)...
        {
            SoltarCharco(posicionCharco, Vector3.zero); // Suelta un charco en esta posición 
            posicionInicial = posicionCharco; // La posición incial cambia a la nueva posición donde se ha soltado el charco.
        }
        if (rb.velocity.x < 0f && transform.position.x < posicionInicial.x - 2f) // Si la pelusa tiene velocidad y la posición en el eje X es la posición inicial más 2 unidades hacia la izquierda
                                                                                 // (posición incial y otra más)...
        {
            SoltarCharco(posicionCharco, Vector3.zero);
            posicionInicial = posicionCharco;
        }
        if(rb.velocity.y > 0f && transform.position.y > posicionInicial.y + 2f) // Si la pelusa tiene velocidad y la posición en el eje Y es la posición inicial más 2 unidades hacia arriba
                                                                                // (posición incial y otra más)...
        {
            SoltarCharco(posicionCharco, new Vector3(0, 0, 90));
            posicionInicial = posicionCharco;
        }
        if (rb.velocity.y < 0f && transform.position.y < posicionInicial.y - 2f) // Si la pelusa tiene velocidad y la posición en el eje X es la posición inicial más 2 unidades hacia abajo
                                                                                 // (posición incial y otra más)...
        {
            SoltarCharco(posicionCharco, new Vector3(0, 0, 90));
            posicionInicial = posicionCharco;
        }
    }

    // Función que instancia los charcos.
    void SoltarCharco(Vector3 posicion, Vector3 rotacion)
    {
        charcoNuevo = Instantiate(charcoPrefab, posicion, transform.rotation); // Crea el charco en la posición elegida.
        charcoNuevo.transform.Rotate(rotacion); // Cambia la rotación del charco.
        charcoNuevo.GetComponent<ParaPelusas>().SetPadre(gameObject);
    }

}

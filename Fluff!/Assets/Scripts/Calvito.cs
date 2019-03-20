/* Calvito.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejaestirpe (Daniel Jiménez)
 * Comentado por @Monchburg (Ramón González)
 * Script que controla la habilidad especial del personaje calvito. 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calvito : MonoBehaviour
{
    // Creación de las variables necesarias para el personaje calvito. 
	Rigidbody2D miCuerpo; // Creación del rigidbody del personaje calvito. 
	public GameObject pelusaNormal; // Creación de un GameObject público, donde introduciremos el prefab del personaje normal. 
	Rigidbody2D rb; // Creación del rigidbody del personaje normal.

    void Start()
    {
        // Inicializamos ambos rigidbodys.
		miCuerpo = GetComponent <Rigidbody2D> ();
		rb = GetComponent <Rigidbody2D> (); 
    }

    void Update()
    {
        
    }

    // Función que gestiona la colisión del personaje calvito. 
	void OnTriggerEnter2D (Collider2D col){
	
		if (col.gameObject.tag == "Peluso") // Si el objeto que ha colisionado tiene el tag "Peluso"...
        {
			GameObject peluso = Instantiate (pelusaNormal, col.transform.position, col.transform.rotation); // Crea una pelusa normal en el lugar donde han colisionado. 
			peluso.GetComponent <Rigidbody2D> ().velocity = rb.velocity; // Iguala la velocidad de la pelusa creada a la que llevaba la pelusa calvita.
			Destroy (gameObject); // Destruye la pelusa calvita.
			Destroy (col.gameObject); // Destruye el peluso. 
            CuentaPelusas.contadorPelusas--; // Resta 1 en la variable para completar los niveles.

		}
	}
}

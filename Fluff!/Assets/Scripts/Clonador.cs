/* Movimiento.cs
 * 19/03/2019
 * Versión: 0.6
 * Realizado por @Cooconuts (Oufan Zhang)
 * Comentado por @Cooconuts (Oufan Zhang)
 * Script que controla lo que hace el prop del clonador
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonador : MonoBehaviour
{
	// Creación de las variables necesarias para el funcionamiento del prop
    // Creación de los 4 puntos de entrega del clonador donde aparecerán los personajes creados que salgan del clonador
	public Transform entregaArriba;
	public Transform entregaAbajo;
	public Transform entregaDerecha;
	public Transform entregaIzquierda;

	static float temporizador = 0f;
	float tiempoPausa = 1f;

	public float fuerza = 100f;
	public Vector2 direccion = Vector2.left;

	GameObject pelusa;

    void Start()
    {
        
    }

 
    // Función que utilizaremos para detectar qué pelusas entran en los triggers del prop
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas") && !col.gameObject.CompareTag("Unido")) // Si el objeto que choca con el collider está en la capa de "Pelusas" y no tiene el tag de "Unido", entramos en el condicional
		{
			pelusa = col.gameObject; // Guardamos el objeto que ha chocadon con el trigger en una variable "pelusa"
        }

        if (col.gameObject.CompareTag("Unido")) // Si el tag es "Unido" entramos en el condicional
        {
            col.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Modificamos la velocidad del padre del objeto que choca a 0
            col.transform.parent.GetComponent<Movimiento>().enMovimiento = false; // Hacemos que el booleano del padre del objeto que choca sea falso para que podamos volver a moverlo cuando se pare 
        }
       

        if (Time.time > temporizador) { // Si el tiempo del juego es mayor que el temporizador que hemos declarado antes entramos en el condicional
			GeneraPelusa (); // Llamamos a la función que crea los clones de la pelusa que entran en el clonador
			temporizador = Time.time + tiempoPausa; // Asignamos al valor de la variable "temporizador" el valor del tiempo del juego más el tiempo de pausa entre que se atraviesa el trigger y se crea la pelusa
		}

		col.gameObject.SetActive (false); // Desactivamos la pelusa que entra en el clonador en vez de eliminarla para que los clones tengan los componentes del original
        CuentaPelusas.contadorPelusas--;
	}

    // Función que se encarga de crear los clones de las pelusas 
	void GeneraPelusa ()
	{
        // Creamos gameobjects donde meteremos los clones que se creen 
		GameObject pelusaClonArriba;
		GameObject pelusaClonAbajo;
		GameObject pelusaClonDerecha;
		GameObject pelusaClonIzquierda;

        // Les añadimos rigidbody a los clones nuevos para añadirles una fuerza en función de la dirección en la que saldrán
		Rigidbody2D rbpelusaArriba;
		Rigidbody2D rbpelusaAbajo;
		Rigidbody2D rbpelusaDerecha;
		Rigidbody2D rbpelusaIzquierda;

        // Esta serie de condiciones hacen que según desde donde entre una pelusa al clonador, se crearán clones en las otras 3 salidas aplicándoles una fuerza en su dirección
		if (entregaArriba != null) {
			pelusaClonArriba = Instantiate (pelusa, entregaArriba.position, entregaArriba.rotation);
			rbpelusaArriba = pelusaClonArriba.GetComponent<Rigidbody2D> ();
			rbpelusaArriba.AddForce (Vector2.up * fuerza);
		}
	
		if (entregaAbajo != null) {
			pelusaClonAbajo = Instantiate (pelusa, entregaAbajo.position, entregaAbajo.rotation);
			rbpelusaAbajo = pelusaClonAbajo.GetComponent<Rigidbody2D> ();
			rbpelusaAbajo.AddForce (Vector2.up * -fuerza);
		}

		if (entregaDerecha != null) {
			pelusaClonDerecha = Instantiate (pelusa, entregaDerecha.position, entregaDerecha.rotation);
			rbpelusaDerecha = pelusaClonDerecha.GetComponent<Rigidbody2D> ();
			rbpelusaDerecha.AddForce (Vector2.left * -fuerza);
		}

		if (entregaIzquierda != null) {
			pelusaClonIzquierda = Instantiate (pelusa, entregaIzquierda.position, entregaIzquierda.rotation);
			rbpelusaIzquierda = pelusaClonIzquierda.GetComponent<Rigidbody2D> ();
			rbpelusaIzquierda.AddForce (Vector2.left * fuerza);
		}
	}
}

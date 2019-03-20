/* Cinta.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Cooconuts (Oufan Zhang)
 * Comentado por @Cooconuts (Oufan Zhang)
 * Script que controla cómo funciona la cinta
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinta : MonoBehaviour
{
    // Declaración de variables
    public float fuerza = 0f;
    public Vector2 direccion = Vector2.left;

    // Función que determina el funcionamiento de la cinta cuando un objeto atraviese el trigger
    private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
			col.transform.position = transform.position; // Cambiamos la posición del objeto que ha atravesado el trigger a la posición de la cinta
			col.GetComponent<Rigidbody2D>().velocity = (direccion * fuerza); // Modificamos la velocidad del objeto que entra en el trigger aplicándole una fuerza en una dirección en concreto
        }
    }
}

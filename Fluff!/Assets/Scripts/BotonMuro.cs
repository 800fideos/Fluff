/* Movimiento.cs
 * 19/03/2019
 * Versión: 0.6
 * Realizado por @Cooconuts (Oufan Zhang)
 * Comentado por @Cooconuts (Oufan Zhang)
 * Script que controla cómo funciona el botón que controla los muros
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonMuro: MonoBehaviour
{
	
	Animator animacion;
	Animator animacionMuro;



    void Start()
    {
		animacion = gameObject.GetComponent<Animator> ();
    }
			
    // Función que controla cuando un objeto entra en contacto con el trigger del botón
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas")) // Si el objeto está en la capa "Pelusas"
		{
			animacion.SetBool("pulsado", true); // Se activa la animación "pulsado"
			Muro.bajado = true; // Se modifica el booleano del script del muro a verdadero
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer ("Pelusas")) // Si el objeto está en la capa "Pelusas"
        {
			animacion.SetBool ("pulsado", false); // Se desactiva la animación "pulsado"
			Muro.bajado = false; // Se modifica el booleano del script del muro a falso

        }
	}

}

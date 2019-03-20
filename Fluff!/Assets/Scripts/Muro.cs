/* Muro.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Cooconuts (Oufan Zhang)
 * Comentado por @Cooconuts (Oufan Zhang)
 * Script que controla lo que hace el prop del muro
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
	public static bool bajado = false; // Definimos un booleano como estático para que el botón pueda acceder y activar la animación

	Animator animacion;

	void Start()
	{
		animacion = GetComponent<Animator> ();
	}
	void Update(){
		if (bajado) { // Si se da la condición de bajado, se activa la animación y por medio del booleano
			animacion.SetBool ("bajado", true);
		} else { // Si no se da la condición de bajado, se desactiva la animación
			animacion.SetBool ("bajado", false);
		}
	}
}

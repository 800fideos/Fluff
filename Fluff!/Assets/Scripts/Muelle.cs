/* Muelle.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Cooconuts (Oufan Zhang)
 * Comentado por @Cooconuts (Oufan Zhang)
 * Script que controla lo que hace el prop del muelle
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muelle : MonoBehaviour
{
	Animator animacion;

    void Start()
    {
		animacion = gameObject.GetComponent<Animator>();

    }

	public void ActivaAnimacion()
	{
		animacion.SetTrigger ("rebote"); // Cuando se colisiona con el trigger se activa la animación "rebote"
	}
}

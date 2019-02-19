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
			
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
		{
			animacion.SetBool("pulsado", true);
			Muro.bajado = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer ("Pelusas")) {
			animacion.SetBool ("pulsado", false);
			Muro.bajado = false;

		}
	}

}

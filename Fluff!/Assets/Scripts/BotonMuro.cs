using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonMuro: MonoBehaviour
{
	public GameObject Muro;
	Animator animacion;
	Animator animacionMuro;



    void Start()
    {
		animacion = gameObject.GetComponent<Animator> ();
		animacionMuro = Muro.GetComponent<Animator> ();
    }
			
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
		{
			animacion.SetBool("pulsado", true);
			animacionMuro.SetBool("bajado", true);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
		{
			animacion.SetBool("pulsado", false);
			animacionMuro.SetBool("bajado", false);

		}
	}

	void bajaMuro ()
	{
		GameObject [] muros = GameObject.FindGameObjectsWithTag ("Muro");

		for (int i = 0; i < muros.Length; i++){
			animacionMuro.SetBool("bajado", true);
		}
	}

	void subeMuro ()
	{
		GameObject [] muros = GameObject.FindGameObjectsWithTag ("Muro");

		for (int i = 0; i < muros.Length; i++){
			animacionMuro.SetBool("bajado", false);
		}
	}

}

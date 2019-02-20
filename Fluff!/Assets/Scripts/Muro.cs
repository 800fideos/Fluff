using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
	public static bool bajado = false;

	Animator animacion;

	void Start()
	{
		animacion = GetComponent<Animator> ();
	}
	void Update(){
		if (bajado) {
			animacion.SetBool ("bajado", true);
		} else {
			animacion.SetBool ("bajado", false);
		}
	}
}

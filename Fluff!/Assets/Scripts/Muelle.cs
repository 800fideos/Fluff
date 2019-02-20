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
		animacion.SetTrigger ("rebote");
	}
}

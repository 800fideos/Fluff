using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muelle : MonoBehaviour
{
	Animator animacion;

	public float fuerza = 0f;
	public Vector2 direccion = Vector2.left;

    void Start()
    {
		animacion = gameObject.GetComponent<Animator>();
    }

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
		{
			animacion.SetTrigger ("rebote");
		}
	}
}

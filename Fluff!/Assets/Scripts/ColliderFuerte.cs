using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFuerte : MonoBehaviour
{
	
	public Vector2 direccion;

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Cono"))
		{
			//col.gameObject.GetComponent<Rigidbody2D>().AddForce(direccion * fuerza);
			col.gameObject.GetComponent<Cono>().MoveryParar((direccion));
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonador : MonoBehaviour
{
	//public float fuerza = 0f;
	//public Vector2 direccion = Vector2.left;

	public Transform entregaArriba;
	public Transform entregaAbajo;
	public Transform entregaDerecha;
	public Transform entregaIzquierda;

	static float temporizador = 0f;
	float tiempoPausa = 1f;

	public float fuerza = 100f;
	public Vector2 direccion = Vector2.left;

	GameObject pelusa;

    void Start()
    {
        
    }

 

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
		{
			pelusa = col.gameObject;
		}



		if(Time.time > temporizador) {
			GeneraPelusa ();
			temporizador = Time.time + tiempoPausa;
		}

		col.gameObject.SetActive (false);
	}

	void GeneraPelusa ()
	{
		GameObject pelusaClonArriba;
		GameObject pelusaClonAbajo;
		GameObject pelusaClonDerecha;
		GameObject pelusaClonIzquierda;

		Rigidbody2D rbpelusaArriba;
		Rigidbody2D rbpelusaAbajo;
		Rigidbody2D rbpelusaDerecha;
		Rigidbody2D rbpelusaIzquierda;

		if (entregaArriba != null) {
			pelusaClonArriba = Instantiate (pelusa, entregaArriba.position, entregaArriba.rotation);
			rbpelusaArriba = pelusaClonArriba.GetComponent<Rigidbody2D> ();
			rbpelusaArriba.AddForce (Vector2.up * fuerza);
		}
	
		if (entregaAbajo != null) {
			pelusaClonAbajo = Instantiate (pelusa, entregaAbajo.position, entregaAbajo.rotation);
			rbpelusaAbajo = pelusaClonAbajo.GetComponent<Rigidbody2D> ();
			rbpelusaAbajo.AddForce (Vector2.up * -fuerza);
		}

		if (entregaDerecha != null) {
			pelusaClonDerecha = Instantiate (pelusa, entregaDerecha.position, entregaDerecha.rotation);
			rbpelusaDerecha = pelusaClonDerecha.GetComponent<Rigidbody2D> ();
			rbpelusaDerecha.AddForce (Vector2.left * -fuerza);
		}

		if (entregaIzquierda != null) {
			pelusaClonIzquierda = Instantiate (pelusa, entregaIzquierda.position, entregaIzquierda.rotation);
			rbpelusaIzquierda = pelusaClonIzquierda.GetComponent<Rigidbody2D> ();
			rbpelusaIzquierda.AddForce (Vector2.left * fuerza);
		}
	}
}

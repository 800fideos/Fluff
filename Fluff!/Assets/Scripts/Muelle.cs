using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muelle : MonoBehaviour
{
	Animator animacion;
	public GameObject desiredPosition;

	public float fuerza = 0f;
	public Vector2 direccion = Vector2.left;
	public Vector3 distanciaParada;

    void Start()
    {
		animacion = gameObject.GetComponent<Animator>();
		//transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), 0);

    }

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
		{
			col.gameObject.GetComponent<Rigidbody2D>().AddForce(direccion * fuerza);
			col.gameObject.GetComponent<Movimiento> ().MoveryParar ((transform.position + distanciaParada));
			animacion.SetTrigger ("rebote");
		}
	}
}

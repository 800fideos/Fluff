using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonador : MonoBehaviour
{
	//public float fuerza = 0f;
	//public Vector2 direccion = Vector2.left;

	public Transform entrega1;
	public Transform entrega2;
	public Transform entrega3;

	GameObject pelusa;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		var tag = col.transform.tag;
		pelusa = col.gameObject;
		GeneraPelusa ();
		Destroy (col.gameObject);
	}

	void GeneraPelusa ()
	{
		GameObject pelusaClon;
		Rigidbody2D rbpelusa;
		Vector2 fuerza;

		pelusaClon = Instantiate (pelusa, entrega1.position, entrega1.rotation);
		pelusaClon = Instantiate (pelusa, entrega2.position, entrega2.rotation);
		pelusaClon = Instantiate (pelusa, entrega3.position, entrega3.rotation);

		fuerza.x = 100f;
		fuerza.y = 100f;

		rbpelusa = pelusaClon.GetComponent<Rigidbody2D> ();
		rbpelusa.AddForce (fuerza);


	}
}

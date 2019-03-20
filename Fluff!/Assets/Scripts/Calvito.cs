using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calvito : MonoBehaviour
{
	Rigidbody2D miCuerpo;
	public GameObject pelusaNormal;
	Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
		miCuerpo = GetComponent <Rigidbody2D> ();
		rb = GetComponent <Rigidbody2D> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D (Collider2D col){
	
		if (col.gameObject.tag == "Peluso") {
			GameObject peluso = Instantiate (pelusaNormal, col.transform.position, col.transform.rotation);
			peluso.GetComponent <Rigidbody2D> ().velocity = rb.velocity;
			Destroy (gameObject);
			Destroy (col.gameObject);
            CuentaPelusas.contadorPelusas--;

		}
	}
}

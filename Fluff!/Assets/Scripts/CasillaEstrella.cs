using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaEstrella : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas")) {
			
			GameController.estrellas++;
			//Queremos que se sume uno al int que hay en GameController cuando el personaje se meta en la casilla de estrella
		}
	}

	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas")) {
			
			GameController.estrellas--;
			//Queremos que se reste uno al int que hay en GameController cuando el personaje salga de la casilla de estrella
		   }
	}
}

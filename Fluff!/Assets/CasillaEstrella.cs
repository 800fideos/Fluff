using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaEstrella : MonoBehaviour
{
	
	bool pisandoFuerte = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.CompareTag ("Unido")) {
			
			GameController.estrellas++;
			//Queremos que se sume uno al int del int que hay en GameController 
		}
	}

	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.CompareTag ("Unido")) {
			
			GameController.estrellas--;
			//Queremos que se sume uno al int del int que hay en GameController 
		}
	}
}

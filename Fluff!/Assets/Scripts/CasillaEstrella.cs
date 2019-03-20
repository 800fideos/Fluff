/* CasillaEstrella.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla el conteo de estrellas obtenidas en un nivel.
 * 
 * */


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

	void OnTriggerEnter2D (Collider2D col){ //Esta función controla que cuando un objeto de la capa Pelusas entre en el collider de la casilla estrella cuente una
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas")) {
			
			GameController.estrellas++;
			//Queremos que se sume uno al int que hay en GameController cuando el personaje se meta en la casilla de estrella
		}
	}

	void OnTriggerExit2D (Collider2D col){ //Esta función controla que cuando un objeto de la capa Pelusas salga del collider de la casilla estrella reste una
		if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas")) {
			
			GameController.estrellas--;
			//Queremos que se reste uno al int que hay en GameController cuando el personaje salga de la casilla de estrella
		   }
	}
}

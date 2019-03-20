/* Score.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla la aparición del menú completado cuando el contador pelusas llega a un número determinado
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
	public GameObject panel; //crea una variable pública que será el menú completado
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (CuentaPelusas.contadorPelusas == 1 ) { //Cuando el contador de pelusas llegue a uno, se activa el panel que contiene el menú completado y se inicia la animación de las tres estrellas

            panel.SetActive (true);
			Debug.Log ("Estrellas " + GameController.estrellas);
			panel.transform.GetChild(0).GetComponent<Animator> ().SetInteger ("estrellas", GameController.estrellas);
        }
    }

}
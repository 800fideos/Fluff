using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
	public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (CuentaPelusas.contadorPelusas == 0 ) {

            panel.SetActive (true);
			Debug.Log ("Estrellas " + GameController.estrellas);
			panel.transform.GetChild(0).GetComponent<Animator> ().SetInteger ("estrellas", GameController.estrellas);

         

        }
    }

}
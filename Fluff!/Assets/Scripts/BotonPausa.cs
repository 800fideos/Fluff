using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPausa : MonoBehaviour
{
	public static bool pausa = true;
	public GameObject camaraMenu;
	public GameObject menuPrincipal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	void Update () {
		if (pausa) {
			Time.timeScale = 0f;

		} 

		else {
			Time.timeScale = 1f;
		}
			
	}

	public void IniciarJuego(){

		pausa = false;
		camaraMenu.SetActive (false);
		menuPrincipal.SetActive (false);
	}

	public void PausarJuego(){

		pausa = true;
		camaraMenu.SetActive (true);
		menuPrincipal.SetActive (true);
	}
}

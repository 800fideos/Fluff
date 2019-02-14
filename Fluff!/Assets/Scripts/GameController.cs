using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static bool pausa = false;
	public GameObject camaraMenu;
	public GameObject menuPrincipal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (pausa) {
			Time.timeScale = 0f;

		} 

		else {
			Time.timeScale = 1f;
		}
    }


	public void Recarga()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

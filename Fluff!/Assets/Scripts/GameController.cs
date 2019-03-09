using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static bool pausa = false;
	public GameObject camaraMenu;
	public GameObject menuPrincipal;

	public static int estrellas = 0;
	Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
		Scene scene = SceneManager.GetActiveScene();
		animacion = gameObject.GetComponent<Animator> ();
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
		pausa = false;
        CuentaPelusas.contadorPelusas = 0;
	}

	public void Siguiente()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		pausa = false;
	}

	public void IniciarJuego(){

		pausa = false;
		menuPrincipal.SetActive (false);
	}

	public void PausarJuego(){

		pausa = true;
		camaraMenu.SetActive (true);
		menuPrincipal.SetActive (true);
	}

	void TresEstrellas(){
		
			animacion.SetInteger ("estrellas", estrellas);

	}


}

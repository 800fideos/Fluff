/* GameController.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla varios aspectos del uego, entre ellos la pausa y sus funciones o la animación de onseguir tres estrellas
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static bool pausa = false; //Booleano que indica que el juego no está en pausa
	public GameObject camaraMenu; //Variable de un objeto que será la cámara el juego
	public GameObject menuPrincipal; //Variable de un objeto que será el canvas que contiene el menú de pausa

	public static int estrellas = 0; //Static que cuenta las estrellas y que comienza en 0
	Animator animacion; //Variable que llama a la animación
    // Start is called before the first frame update
    void Start()
    {
		Scene scene = SceneManager.GetActiveScene(); //esta línea recoge la escena en la que nos encotremos
		animacion = gameObject.GetComponent<Animator> (); //Inicializamos la variable animacion
    }

    // Update is called once per frame
    void Update()
    {
		if (pausa) { //Si el booleano se activa el tiempo se detiene
			Time.timeScale = 0f;

		} 

		else { //Cualquier otra poibilidad aparte del booleano estando activo hace que el tiempo siga
			Time.timeScale = 1f;
		}

    }


	public void Recarga() //Carga la escena en la que nos encontramos
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		pausa = false; //Quita la pausa
        CuentaPelusas.contadorPelusas = 0;//Reinicia el contador de pelusas
        Muro.bajado = false; //Reinicia la posicón de los muros
	}

	public void Siguiente() //Carga la siguiente escena, quitando la pausa y reiniciando el contador de pelusas
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		pausa = false;
        CuentaPelusas.contadorPelusas = 0;
	}

	public void IniciarJuego(){ //Al comenzar la escena la pausa estará en false y el menú de pausa desactivado

		pausa = false;
		menuPrincipal.SetActive (false);
	}

	public void PausarJuego(){//Al pausar el juego, el booleano estará en true, se detendrá la cámara y se activará el menú de pausa

		pausa = true;
		camaraMenu.SetActive (true);
		menuPrincipal.SetActive (true);
	}

	void TresEstrellas(){ //Se inicia la animación de las tres estrellas
		
			animacion.SetInteger ("estrellas", estrellas);

	}


}

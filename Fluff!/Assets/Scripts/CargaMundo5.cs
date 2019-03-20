/* CargaMundo5.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla las cargas de escenas, en este caso los niveles del mundo 5.
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CargaMundo5 : MonoBehaviour
{
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void CargaNivel15()  //Esta y las sucesivas fuciones se encargan de cargar la escena que contiene los niveles 1 hasta el cinco del mundo 5
    {
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo5_Nivel1");
	}

	public void CargaNivel25()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo5_Nivel2");
	}

	public void CargaNivel35()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo5_Nivel3");
	}


	public void CargaNivel45()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo5_Nivel4");
	}


	public void CargaNivel55()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo5_Nivel5");
	}
}

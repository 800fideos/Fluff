/* CargaMundo2.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla las cargas de escenas, en este caso los niveles del mundo 2.
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaMundo2 : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void CargaNivel12() //Esta y las sucesivas fuciones se encargan de cargar la escena que contiene los niveles 1 hasta el cinco del mundo 2
    {
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo2_Nivel1");
	}

	public void CargaNivel22()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo2_Nivel2");
	}

	public void CargaNivel32()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo2_Nivel3");
	}


	public void CargaNivel42()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo2_Nivel4");
	}


	public void CargaNivel52()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo2_Nivel5");
	}
}

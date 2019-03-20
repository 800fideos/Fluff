/* CargaMundo4.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla las cargas de escenas, en este caso los niveles del mundo 4.
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CargaMundo4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void CargaNivel14()   //Esta y las sucesivas fuciones se encargan de cargar la escena que contiene los niveles 1 hasta el cinco del mundo 4
    {
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo4_Nivel1");
	}

	public void CargaNivel24()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo4_Nivel2");
	}

	public void CargaNivel34()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo4_Nivel3");
	}


	public void CargaNivel44()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo4_Nivel4");
	}


	public void CargaNivel54()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mundo4_Nivel5");
	}
}

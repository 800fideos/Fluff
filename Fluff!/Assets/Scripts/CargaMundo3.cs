/* CargaMundo3.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla las cargas de escenas, en este caso los niveles del mundo 3.
 * 
 * */

using UnityEngine;
using UnityEngine.SceneManagement;


public class CargaMundo3 : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	public void CargaNivel13()  //Esta y las sucesivas fuciones se encargan de cargar la escena que contiene los niveles 1 hasta el cinco del mundo 3
    {
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mudo3_Nivel1");
	}

	public void CargaNivel23()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mudo3_Nivel2");
	}

	public void CargaNivel33()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mudo3_Nivel3");
	}


	public void CargaNivel43()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mudo3_Nivel4");
	}


	public void CargaNivel53()
	{
		//IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
		SceneManager.LoadScene("Mudo3_Nivel5");
	}
}

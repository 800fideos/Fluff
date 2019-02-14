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
	public void CargaNivel13()
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

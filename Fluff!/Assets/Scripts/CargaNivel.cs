using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaNivel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CargaMundo1()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo1");
        CambiarCancion(2);

    }

    public void CargaMundo2()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo2seleccion");
        CambiarCancion(3);
    }


    public void CargaMundo3()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo3seleccion");
        CambiarCancion(4);
    }


    public void CargaMundo4()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo4seleccion");
        CambiarCancion(5);
    }


    public void CargaMundo5()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo5seleccion");
        CambiarCancion(6);
    }

    public void CambiarCancion(int nivel) {
        GameObject musica = GameObject.Find("Musica");
        if (musica != null) {
            musica.GetComponent<GameManager>().CambiarCancion(nivel);
        }
    }
}

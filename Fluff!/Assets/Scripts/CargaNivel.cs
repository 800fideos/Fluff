/* CargaNivel.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla la carga de escenas, en concreto de la selección de niveles de cada mundo en concreto y el cambio de música.
 * 
 * */


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


    public void CargaMundo1() //Esta y las sucesivas fuciones se encargan de cargar la escena que contiene los mundos 1 hasta el cinco
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo1");
        CambiarCancion(2);
        GameController.pausa = false; //Quita la pausa
        CuentaPelusas.contadorPelusas = 0; //Reinicia el conteo de pelusas
    }

    public void CargaMundo2()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo2seleccion");
        CambiarCancion(3);
        GameController.pausa = false;
        CuentaPelusas.contadorPelusas = 0;
    }


    public void CargaMundo3()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo3seleccion");
        CambiarCancion(4);
        GameController.pausa = false;
        CuentaPelusas.contadorPelusas = 0;
    }


    public void CargaMundo4()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo4seleccion");
        CambiarCancion(5);
        GameController.pausa = false;
        CuentaPelusas.contadorPelusas = 0;
    }


    public void CargaMundo5()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo5seleccion");
        CambiarCancion(6);
        GameController.pausa = false;
        CuentaPelusas.contadorPelusas = 0;
    }

    public void CambiarCancion(int nivel) { //Esta función se encaga de encontrar la música pertenecien a esta escena y cambiarla cuando se cambie a la siguiente
        GameObject musica = GameObject.Find("Musica");
        if (musica != null) {
            musica.GetComponent<GameManager>().CambiarCancion(nivel);
        }
    }
}

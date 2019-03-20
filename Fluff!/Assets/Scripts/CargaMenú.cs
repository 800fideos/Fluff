/* CargaMenú.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla la carga de escenas, en concreto de la selección de mundos y el menú principal.
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaMenú : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CargaNivel() //esta función carga la escena indicada más abajo entre comillas
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("seleccionmundos");
    }

    public void CargaMenu() //esta función carga la escena indicada más abajo entre comillas
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("DaniScene");
    }

}

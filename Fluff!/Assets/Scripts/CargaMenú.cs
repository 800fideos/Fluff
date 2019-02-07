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


    public void CargaNivel()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("seleccionmundos");
    }

    public void CargaMenu()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("DaniScene");
    }

}

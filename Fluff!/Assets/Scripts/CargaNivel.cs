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
    }

    public void CargaMundo2()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo2seleccion");
    }


    public void CargaMundo3()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo3seleccion");
    }


    public void CargaMundo4()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo4seleccion");
    }


    public void CargaMundo5()
    {
        //IMPORTANTE PONER ARRIBA using UnityEngine.SceneManagement;//
        SceneManager.LoadScene("mundo5seleccion");
    }
}

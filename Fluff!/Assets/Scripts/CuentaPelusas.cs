using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaPelusas : MonoBehaviour
{
	public static int contadorPelusas = 0;
    // Start is called before the first frame update
    void Start()
    {

        contadorPelusas++;
        if (transform.gameObject.tag == "Calvito")
        {
            contadorPelusas--;
        }
     
        

		Debug.Log (contadorPelusas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

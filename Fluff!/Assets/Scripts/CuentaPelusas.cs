/* CuentaPelusas.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que se dedica a contar las pelusas que hay en escena
 * 
 * */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaPelusas : MonoBehaviour
{
	public static int contadorPelusas = 0; //Se genera una variable static a la que puedan acceder los demás scripts y que esté a 0
    // Start is called before the first frame update
    void Start()
    {
        contadorPelusas++; //Al cargar la escena se suman todas las pelusas que tengan este script
     
		Debug.Log (contadorPelusas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

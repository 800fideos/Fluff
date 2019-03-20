/* AutoRecolocamiento.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Cooconuts (Oufan Zhang)
 * Comentado por @Cooconuts (Oufan Zhang)
 * Script que reubica automáticamente los elementos que tengan este script a coordenadas redondas
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRecolocamiento : MonoBehaviour
{
    void Start()
    {
		transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), 0); // Asignamos a la posición del objeto que tiene el script a un vector nuevo en coordenadas redondas en cada eje menos el Z
    }

}

/* ParaPelusas.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @monchburg (Ramón González)
 * Comentado por @monchburg (Ramón González)
 * Script que para las pelusas en los charcos.
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaPelusas : MonoBehaviour
{
    GameObject miPadre;

    void Start()
    { 

    }

    void Update()
    {
        
    }

    //Función que controla las colisiones con el charco.
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Si el objeto que colisiona es una pelusa, no tiene padre y no está unida con nada.
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas") && col.gameObject != miPadre && !col.gameObject.GetComponent<UnionPelusas>().pelusaUnida)
        {
            col.transform.position = transform.position; // Iguala la posición de la pelusa a la del charco. 
            col.GetComponent<Rigidbody2D>().velocity = (col.transform.position * 0); // Frena a la pelusa que ha entrado en el charco.
            col.GetComponent<Movimiento>().enMovimiento = false; // Desactiva el booleano para que la pelusa pueda moverse de nuevo. 
        }
    }
    public void SetPadre(GameObject padre)
    {
        miPadre = padre;
    }
}

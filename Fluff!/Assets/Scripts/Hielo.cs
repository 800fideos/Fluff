/* Hielo.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Cooconuts (Oufan Zhang)
 * Comentado por @Cooconuts (Oufan Zhang)
 * Script que controla lo que hace el prop del hielo
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hielo : MonoBehaviour
{
   
    Animator animacion;

    void Start()
    {
        animacion = gameObject.GetComponent<Animator>();
    }

    // Función que activa la animación dependiendo de la condición booleana "roto" al colisionar con el bloque de hielo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pelusas")) // Si el objeto que choca está en la capa de "Pelusas"
        {
            animacion.SetBool("roto", true); // Se activa la animación en función de la condición
            Invoke("Destruir", 0.2f); // Utilizamos la función invocar para ejecutar la función "Destruir" después de 0.2s
        }
    }

    private void Destruir()
    {
        Destroy (gameObject); // Se destruye el objeto cuando se ejecuta la función "Destruir"
    }



}

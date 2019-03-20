/* Movimiento.cs
 * 19/03/2019
 * Versión: 0.6
 * Realizado por @Cooconuts (Oufan Zhang)
 * Comentado por @Cooconuts (Oufan Zhang)
 * Script que controla cómo reaccionan los colliders del muelle cuando una pelusa choquen con ellos
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMuelle : MonoBehaviour
{
    // Se declaran las variables públicas necesarias para el funcionamiento del prop para poder editarlas desde el editor
    public GameObject Muelle;
    public float fuerza = 100f;
    public Vector2 direccion = Vector2.left;
    public Vector3 distanciaParada;

    void Update()
    {
        
    }

    // Función que hace funcionar el muelle
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas")) 
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(direccion * fuerza); // Cuando el objeto choque con el collider, se busca su rigidbody y se le añade una fuerza en una dirección concreta
            col.gameObject.GetComponent<Movimiento>().MoveryParar((transform.position + distanciaParada)); // Cuando el objeto choque con el collider, accedemos a su script de movimiento y le metemos un parámetro para parar el objeto a una distancia concreta
            Muelle.GetComponent<Animator>().SetTrigger("rebote"); // Se activa la animación "rebote" activando la condición de trigger del muelle en sí
        }
    }
}

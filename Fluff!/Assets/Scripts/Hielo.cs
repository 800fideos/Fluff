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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            animacion.SetBool("roto", true);
            Invoke("Destruir", 0.2f);
        }
    }

    private void Destruir()
    {
        Destroy (gameObject);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionPadres : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject padreDePadres;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void CreaPadreDePadres()
    {
        padreDePadres = new GameObject();
        padreDePadres.AddComponent<Movimiento>();
        padreDePadres.AddComponent<UnionPadres>();
        padreDePadres.gameObject.tag = "Unido";
        AniadirRigidBodyAPadreDePadres();
        AniadirAudioSourceAPadreDePadres();

        /**/padreDePadres.AddComponent<Collider2D>();
    }
    private void AniadirRigidBodyAPadreDePadres()
    {
        padreDePadres.AddComponent<Rigidbody2D>();
        padreDePadres.GetComponent<Rigidbody2D>().gravityScale = 0;
        padreDePadres.GetComponent<Rigidbody2D>().simulated = true;
        padreDePadres.GetComponent<Rigidbody2D>().freezeRotation = true;
        padreDePadres.GetComponent<Rigidbody2D>().mass = 0.1f;
        padreDePadres.layer = LayerMask.NameToLayer("Pelusas");
    }

    private void AniadirAudioSourceAPadreDePadres()
    {
        padreDePadres.AddComponent<AudioSource>();
        padreDePadres.GetComponent<Movimiento>().sonidoChoque = GetComponent<Movimiento>().sonidoChoque;
    }

    private void UnirPadres(GameObject OtroPadre)
    {
        Destroy(OtroPadre.transform.GetComponent<Rigidbody2D>());
        CreaPadreDePadres();
        transform.parent = padreDePadres.transform;
        OtroPadre.transform.parent = padreDePadres.transform;
        OtroPadre.gameObject.GetComponent<UnionPelusas>().pelusaUnida = true;
        OtroPadre.gameObject.GetComponent<UnionPelusas>().padre = padreDePadres;
        OtroPadre.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        OtroPadre.transform.gameObject.tag = "Unido";
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.parent != transform && rb != null)
        {
            UnirPadres(col.gameObject);
        }
    }
}

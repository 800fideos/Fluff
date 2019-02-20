using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMuelle : MonoBehaviour
{
    public GameObject Muelle;
    public float fuerza = 100f;
    public Vector2 direccion = Vector2.left;
    public Vector3 distanciaParada;

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(direccion * fuerza);
            col.gameObject.GetComponent<Movimiento>().MoveryParar((transform.position + distanciaParada));
            Muelle.GetComponent<Animator>().SetTrigger("rebote");

        }
    }
}

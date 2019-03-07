using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionPadres : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void UnirPadres(GameObject OtroPadre)
    {
        for (int i = 0; i < OtroPadre.transform.childCount; i++)
        {
            OtroPadre.transform.GetChild(0).transform.parent = transform.parent;
        }
        Destroy(OtroPadre);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.parent == null &&
                col.transform.childCount > 0 &&
                !GetComponent<Movimiento>().enMovimiento)
        {
            UnirPadres(col.gameObject);
        }
    }
}

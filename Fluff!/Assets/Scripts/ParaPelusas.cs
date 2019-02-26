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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas") && col.gameObject != miPadre && !col.gameObject.GetComponent<UnionPelusas>().pelusaUnida)
        {
            col.GetComponent<Rigidbody2D>().velocity = (col.transform.position * 0);
        }
    }
    public void SetPadre(GameObject padre)
    {
        miPadre = padre;
    }
}

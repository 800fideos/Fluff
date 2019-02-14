using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionPelusas : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            col.transform.parent = transform;
        }
    }
}

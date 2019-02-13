using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaPelusas : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            col.transform.position = transform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hielo : MonoBehaviour
{
    Animator animacion;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Pelusa"))
        {

            Destroy (gameObject);
        }
    }
}

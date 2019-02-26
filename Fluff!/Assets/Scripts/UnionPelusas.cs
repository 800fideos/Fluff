using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionPelusas : MonoBehaviour
{
    Rigidbody2D rb;

    bool golpeTop = false;
    bool golpeBot = false;
    bool golpeRight = false;
    bool golpeLeft = false;
    SpriteRenderer sr;
    public Sprite[] spritePelusa;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (golpeTop)
        {
            Debug.DrawRay(transform.position, Vector2.up, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.up, Color.yellow);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas") && col.transform.parent == null)
        {
            Destroy(rb);
            transform.parent = col.transform;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        RaycastHit2D hitTop = Physics2D.Raycast(transform.position, Vector2.up);

      
        Debug.Log("Did Hit");

        if (hitTop.collider != null)
        {
            if (GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer ("Pelusas"))
            {
                UnirPelusas();
            }
        }
    }

    void UnirPelusas()
    {
        if (golpeTop)
        {
            sr.sprite = spritePelusa[0];
        }
        else if (golpeBot)
            {
                sr.sprite = spritePelusa[1];
            }
            else if (golpeLeft)
                {
                    sr.sprite = spritePelusa[2];
                }
                else if (golpeRight)
                    {
                        sr.sprite = spritePelusa[3];
                    }
                
            
        
    }
}

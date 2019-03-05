using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionPelusas : MonoBehaviour
{
    enum Direccion
    {
        Arriba,
        Derecha,
        Abajo,
        Izquierda
    };

    Rigidbody2D rb;
    public bool[] alrededorPelusas = new bool[4];

    bool golpeTop = false;
    bool golpeBot = false;
    bool golpeRight = false;
    bool golpeLeft = false;
    SpriteRenderer sr;
    public Sprite[] spritePelusa;

    public bool pelusaUnida = false;
    public GameObject padre;
    public float rayDist = 0.2f;
    public int sumaSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        LanzarRaycastsAlrededor();
    }

    private void CrearPadrePelusas()
    {
        padre = new GameObject();
        padre.AddComponent<Movimiento>();
        AniadirRigidBodyAPadre();
    }

    private void AniadirRigidBodyAPadre()
    {
        padre.AddComponent<Rigidbody2D>();
        padre.GetComponent<Rigidbody2D>().gravityScale = 0;
        padre.GetComponent<Rigidbody2D>().simulated = true;
        padre.GetComponent<Rigidbody2D>().freezeRotation = true;
        padre.GetComponent<Rigidbody2D>().mass = 0.1f;
        padre.layer = LayerMask.NameToLayer("Pelusas");
    }

    private void IniciarUniones()
    {
        pelusaUnida = true;
        Destroy(rb);
        CrearPadrePelusas();
    }


    private void CambiarSprites(bool[] alrededorPelusas)
    {
        
        for (int i = 0; i < spritePelusa.Length; i++)
        {
            // 0 Sprite default
            // 1 Sprite simple arriba
            // 2 Sprite simple derecha
            // 3 Sprite Arriba y Derecha
            // 4 Sprite simple abajo
            // 5 Sprite Arriba y Abajo
            // 6 Sprite Derecha y Abajo
            // 7 Sprite Arriba, derecha y Abajo
            // 8 simple Izquierda
            // 9 Sprite Izquierda y Arriba
            // 10 Sprite Izquierda y Derecha
            // 11 Izquierda , derecha y arriba
            // 12 Izquierda y Abajo
            // 13 Izquierda , abajo y arriba
            // 14 Izquierda, Abajo y Derecha
            // 15 Central
            sumaSprite = 0;
            
            // 0 Arriba
            // 1 derecha
            // 2 Abajo
            // 3 Izquierda
            if (alrededorPelusas[(int)Direccion.Arriba] == true)
            {
                sumaSprite = sumaSprite + 1;
            }
            if (alrededorPelusas[(int)Direccion.Derecha] == true)
            {
                sumaSprite = sumaSprite + 2;
            }
            if (alrededorPelusas[(int)Direccion.Abajo] == true)
            {
                sumaSprite = sumaSprite + 4;
            }
            if (alrededorPelusas[(int)Direccion.Izquierda] == true)
            {
                sumaSprite = sumaSprite + 8;
            }
            Debug.Log("sprite" + sumaSprite);
            sr.sprite = spritePelusa[sumaSprite];
        }
    }

    private bool LanzarRaycast(Vector2 direccion, Vector2 position)
    {
        Collider2D collider = Physics2D.Raycast(position, direccion, rayDist).collider;


        Debug.DrawRay(position, direccion * rayDist, Color.red);

        // DEBUG
        if (collider != null)
        {
            Debug.Log(gameObject.name + " etá detectando: " + collider.gameObject.name);
        }

        return (collider != null && collider.gameObject.layer == LayerMask.NameToLayer("Pelusas"));
    }

    private bool LanzarRaycastArriba()
    {
        return LanzarRaycast(Vector2.up, new Vector2(transform.position.x, (transform.position.y + gameObject.GetComponent<Collider2D>().bounds.size.y / 2 + 0.1f)));
    }

    private bool LanzarRaycastDerecha()
    {
        return LanzarRaycast(Vector2.right, new Vector2(transform.position.x + gameObject.GetComponent<Collider2D>().bounds.size.x / 2 + 0.1f, transform.position.y));
    }

    private bool LanzarRaycastAbajo()
    {
        return LanzarRaycast(Vector2.down, new Vector2(transform.position.x, (transform.position.y - gameObject.GetComponent<Collider2D>().bounds.size.y / 2 - 0.1f)));
    }

    private bool LanzarRaycastIzquierdo()
    {
        return LanzarRaycast(Vector2.left, new Vector2((transform.position.x - gameObject.GetComponent<Collider2D>().bounds.size.x / 2 - 0.1f), transform.position.y));
    }

    private void LanzarRaycastsAlrededor()
    {
        
        // 0 Arriba
        // 1 derecha
        // 2 Abajo
        // 3 Izquierda

        alrededorPelusas[(int)Direccion.Arriba] = LanzarRaycastArriba();
        alrededorPelusas[(int)Direccion.Derecha] = LanzarRaycastDerecha();
        alrededorPelusas[(int)Direccion.Abajo] = LanzarRaycastAbajo();
        alrededorPelusas[(int)Direccion.Izquierda] = LanzarRaycastIzquierdo();

        //DEBUG
        Debug.Log("[" + gameObject.name + "]: " + "Colisión arriba --> " + alrededorPelusas[0]);
        Debug.Log("[" + gameObject.name + "]: " + "Colisión derecha --> " + alrededorPelusas[1]);
        Debug.Log("[" + gameObject.name + "]: " + "Colisión Abajo --> " + alrededorPelusas[2]);
        Debug.Log("[" + gameObject.name + "]: " + "Colisión Izquierda --> " + alrededorPelusas[3]);

        CambiarSprites(alrededorPelusas);
    }

    private void RevisarPelusasHijas()
    {
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<UnionPelusas>().LanzarRaycastsAlrededor();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas"))
        {
            if (col.transform.parent == null &&
                col.gameObject.GetComponent<UnionPelusas>() != null &&
                !col.gameObject.GetComponent<UnionPelusas>().pelusaUnida)
            {
                if (rb != null)
                { // Primera vez que se une
                    IniciarUniones();
                }
                UnirPelusa(col);
            }
            else
            {
                if (transform.parent != null) {
                    transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                    
            }

            RevisarPelusasHijas();
        }
    }

    void UnirPelusa(Collision2D col)
    {
        Destroy(col.gameObject.GetComponent<Rigidbody2D>());
        transform.parent = padre.transform;
        col.transform.parent = padre.transform;
        col.gameObject.GetComponent<UnionPelusas>().pelusaUnida = true;
        col.gameObject.GetComponent<UnionPelusas>().padre = padre;
        padre.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}

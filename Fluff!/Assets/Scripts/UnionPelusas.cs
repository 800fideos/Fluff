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

    public bool pelusaUnida = false;
    public GameObject padre;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (pelusaUnida)
        RevisarPelusasHijas();

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
        int sumaSprite = 0;
        for (int i = 0; i < spritePelusa.Length; i++)
        {
            // 0 Sprite default
            // 1 Sprite simple arriba
            // 2 Sprite simple abajo
            // 3 Sprite simple derecha
            // 4 Sprite simple izquierda
            // 5 Sprite esquina arriba izquierda
            // 6 Sprite esquina arriba derecha
            // 7 Sprite esquina abajo izquierda
            // 8 Sprite esquina abajo derecha
            // 9 Sprite centro horizontal
            // 10 Sprite centro horizontal abajo (sin pelo)
            // 11 Sprite centro vertical 
            // 12 Sprite centro vertical izquierda
            // 13 Sprite centro vertical derecha
            // 14 Sprite central 

            if (alrededorPelusas[0] == true)
            {
                sumaSprite = sumaSprite + 8;
            }
            if (alrededorPelusas[1] == true) {
                sumaSprite = sumaSprite + 1;
            }
            if (alrededorPelusas[2] == true)
            {
                sumaSprite = sumaSprite + 2;
            }
            if (alrededorPelusas[3] == true)
            {
                sumaSprite = sumaSprite + 4;
            }
            sr.sprite = spritePelusa[sumaSprite];
        }
    }

    private bool LanzarRaycast(Vector2 direccion, Vector2 position)
    {
        Collider2D collider = Physics2D.Raycast(position, direccion, 0.1f).collider;


        Debug.DrawRay(position, direccion, Color.red);

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
        return LanzarRaycast(Vector2.down, new Vector2(transform.position.x, -(transform.position.y + gameObject.GetComponent<Collider2D>().bounds.size.y / 2 + 0.1f)));
    }

    private bool LanzarRaycastIzquierdo()
    {
        return LanzarRaycast(Vector2.left, new Vector2(-(transform.position.x + gameObject.GetComponent<Collider2D>().bounds.size.x / 2 + 0.1f), transform.position.y));
    }

    private void LanzarRaycastsAlrededor()
    {
        bool[] alrededorPelusas = new bool[4];
        // 0 Arriba
        // 1 derecha
        // 2 Abajo
        // 3 Izquierda

        alrededorPelusas[0] = LanzarRaycastArriba();
        alrededorPelusas[1] = LanzarRaycastDerecha();
        alrededorPelusas[2] = LanzarRaycastAbajo();
        alrededorPelusas[3] = LanzarRaycastIzquierdo();
        
        //DEBUG
        Debug.Log("[" + gameObject.name + "]: " + "Colisión arriba --> " + alrededorPelusas[0]);
        Debug.Log("[" + gameObject.name + "]: " + "Colisión derecha --> " + alrededorPelusas[1]);
        Debug.Log("[" + gameObject.name + "]: " + "Colisión Abajo --> " + alrededorPelusas[2]);
        Debug.Log("[" + gameObject.name + "]: " + "Colisión Izquierda --> " + alrededorPelusas[3]);

        CambiarSprites(alrededorPelusas);
    }

    private void RevisarPelusasHijas()
    {
        for (int i = 0; i <  transform.parent.transform.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<UnionPelusas>().LanzarRaycastsAlrededor();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas")){
            if (col.transform.parent == null &&
                col.gameObject.GetComponent<UnionPelusas>() != null &&
                !col.gameObject.GetComponent<UnionPelusas>().pelusaUnida)
            {
                if (rb != null) { // Primera vez que se une
                    IniciarUniones();
                }
                UnirPelusa(col);
            }
            else
            {
                transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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

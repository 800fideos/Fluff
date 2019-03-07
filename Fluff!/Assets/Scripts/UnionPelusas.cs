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
        
    }

    private void CrearPadrePelusas()
    {
        padre = new GameObject();
        padre.AddComponent<Movimiento>();
        AniadirRigidBodyAPadre();
        AniadirAudioSourceAPadre();

        /**/padre.AddComponent<Collider2D>();

    }

    private void AniadirAudioSourceAPadre()
    {
        padre.AddComponent<AudioSource>();
        padre.GetComponent<Movimiento>().sonidoChoque = GetComponent<Movimiento>().sonidoChoque;
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
            // 1 Sprite Izquierda           (Colisión Derecha)
            // 2 Sprite Arriba              (Colisión Abajo)
            // 3 Sprite Arriba Izquierda    (Colisión Abajo y Derecha)
            // 4 Sprite Derecha             (Colisión Izquierda)
            // 5 Sprite Central Vertical    (Colisión Izquierda y Derecha)
            // 6 Sprite Arriba Derecha      (Colisión Abajo Izquierda)
            // 7 Sprite Central Arriba      (Colisión Abajo, Derecha e Izquierda)
            // 8 Sprite Abajo               (Colisión Arriba)
            // 9 Sprite Abajo Izquierda     (Colisión Arriba Derecha)
            // 10 Sprite Central Horizontal (Colisión Arriba y Abajo)
            // 11 Sprite Central V Izquierda(Colisión Arriba, Abajo y Derecha 
            // 12 Sprite Abajo Derecha      (Colisión Arriba Izquierda)
            // 13 Sprite Central Abajo      (Colisión Arriba, Derecha e Izquierda)
            // 14 Spirte Central V Derecha  (Colisión Arriba, Abajo e Izquierda)
            // 15 Sprite Central            (Colisión por todos lados)
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
            
            sr.sprite = spritePelusa[sumaSprite];
        }
    }

    private bool LanzarRaycast(Vector2 direccion, Vector2 position)
    {
        Collider2D collider = Physics2D.Raycast(position, direccion, rayDist).collider;

        Debug.DrawRay(position, direccion * rayDist, Color.red);

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
					CuentaPelusas.contadorPelusas--;
					Debug.Log (CuentaPelusas.contadorPelusas);
                }
                UnirPelusa(col);
                LanzarRaycastsAlrededor();
				CuentaPelusas.contadorPelusas--;
                col.transform.position = new Vector3(Mathf.Round(col.transform.position.x), Mathf.Round(col.transform.position.y), 0);
                transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
				transform.gameObject.tag = "Unido";
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
		col.transform.gameObject.tag = "Unido";
    }
}

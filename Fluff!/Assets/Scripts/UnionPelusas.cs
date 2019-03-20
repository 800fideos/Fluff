/* UnionPelusas.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @monchburg (Ramón González)
 * Comentado por @monchburg (Ramón González)
 * Script que controla la unión entre pelusas. 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionPelusas : MonoBehaviour
{
    // Creación de una enumeración para ver el código más claro.
    enum Direccion
    {
        Arriba,
        Derecha,
        Abajo,
        Izquierda
    };

    // Creación de las variables necesarias para la unión de dos pelusas.
    Rigidbody2D rb;
    public bool[] alrededorPelusas = new bool[4]; // Array que contendrá el booleano para saber si un raycast ha sido activado. 

    SpriteRenderer sr;
    public Sprite[] spritePelusa; // Array que contendrá los distintos sprites necesarios para que cambien al unirse.

    public bool pelusaUnida = false; // Bool que controla si una pelusa está unida a otra.
    public GameObject padre; // Padre en el cual se contendrán las pelusas que se unan entre sí.
    public float rayDist = 0.2f; // Longitud que tendrá el raycast. 
    public int sumaSprite; // Variable que usaremos en la ecuación para el cambio del sprite. 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    // Función que crea un padre cuando dos pelusas se unen.
    private void CrearPadrePelusas()
    {
        padre = new GameObject(); // Creación del GameObject. 
        padre.AddComponent<Movimiento>(); // Se le añade el script de movimiento al padre.
        padre.AddComponent<UnionPadres>(); // Se le añade el script de la union entre padres.
        padre.AddComponent<CuentaPelusas>(); // Se le añade el script que cuenta las pelusas para poder completar niveles. 
        padre.gameObject.tag = "Unido"; // Se le aplica el tag "unido" al padre.
        AniadirRigidBodyAPadre(); // Llamada a la función que le añade un rigidbody al padre. 
        AniadirAudioSourceAPadre(); // Llamada a la función que le añade el audio source al padre.

        /**/padre.AddComponent<Collider2D>(); // Se le añade un collider al padre. 

    }

    // Función que añade un audio source al padre para que reproduzca sonido. 
    private void AniadirAudioSourceAPadre()
    {
        padre.AddComponent<AudioSource>(); // Se le añade el componente audio source. 
        //padre.GetComponent<Movimiento>().sonidoChoque = GetComponent<Movimiento>().sonidoChoque; // Esta línea es la que hace que el padre tenga el sonido de choque como las demás pelusas
                                                                                                   // debido a un error que daba, la línea se encuentra comentada.
    }

    // Función que añade el rigidbody al padre, para que así pueda moverse. 
    private void AniadirRigidBodyAPadre()
    {
        padre.AddComponent<Rigidbody2D>(); // Se le añade el componente rigidbody. 
        padre.GetComponent<Rigidbody2D>().gravityScale = 0; // Hacemos que la gravedad del padre sea 0. 
        padre.GetComponent<Rigidbody2D>().simulated = true; 
        padre.GetComponent<Rigidbody2D>().freezeRotation = true; // Congelamos la rotación del padre, para que no haya problemas al chocar con otras pelusas. 
        padre.GetComponent<Rigidbody2D>().mass = 0.1f; // Ponemos la masa del padre en el valor 0,1. 
        padre.layer = LayerMask.NameToLayer("Pelusas"); // Añadimos al padre a la capa "pelusas".
    }

    // Función que controla la creación del padre, además de la primera unión.
    private void IniciarUniones()
    {
        pelusaUnida = true; // Activa el estado en el que la pelusa está unida.
        Destroy(rb); // Destruye el rigidbody de la pelusa para que pueda ser controlada por el padre.
        CrearPadrePelusas(); // Llamada a la función en la que se crea el padre.
    }

    // Función que controlará el cambio de sprites, dependiendo por donde haya golpeado una pelusa.
    private void CambiarSprites(bool[] alrededorPelusas)
    {
        
        for (int i = 0; i < spritePelusa.Length; i++) // Se recorre el array de los sprites para comprobar que sprite es el correcto para cambiarlo. 
        {
            // Lista de como están ordenados los sprites, dependiendo de las colisiones que están activas se acumulará un resultado en la variable sumaSprite, este resultado determinará que 
            // sprite debe mostrarse.  

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

            sumaSprite = 0; // Hacemos que la variable que controla este mecanismo empiece en 0, sumándole x cantidad dependiendo de los raycast que están activos. 
            
            if (alrededorPelusas[(int)Direccion.Arriba] == true) // Si el raycast lanzado hacia arriba está activo...
            {
                sumaSprite = sumaSprite + 1; // Sumaremos 1 a la variable y mostraremos el sprite adecuado según el resultado. 
            }
            if (alrededorPelusas[(int)Direccion.Izquierda] == true) // Si el raycast lanzado hacia la izquierda está activo...
            {
                sumaSprite = sumaSprite + 2; // Sumaremos 2 a la variable.
            }
            if (alrededorPelusas[(int)Direccion.Abajo] == true) // Si el raycast lanzado hacia abajo está activo...
            {
                sumaSprite = sumaSprite + 4; //  Sumaremos 4 a la variable. 
            }
            if (alrededorPelusas[(int)Direccion.Derecha] == true) // Si el raycast lanzado hacia la derecha está activo...
            {
                sumaSprite = sumaSprite + 8; // Sumaremos 8 a la variable. 
            }
            
            sr.sprite = spritePelusa[sumaSprite]; // Seleccionará el sprite que se encuentre en la posición x del array de sprites.
        }
        // Para aclarar un poco más la función y el porque sumamos las cantidades 4 y 8 porque son los siguientes números en las combinaciones, es decir, si activar el raycast derecho suma 1 y el 
        // inferior 2, la activación de ambos a la vez tendría que darnos 3, por tanto, la siguiente combinación posible sería el siguiente raycast en solitario (abajo suma 4), lo mismo ocurre con 
        // hasta que la siguiente combinación posible es el raycast superior en solitario.
    }

    // Función que se encarga de lanzar los raycast y devuelve si este ha chocado con una pelusa. A esta función le pasaremos una dirección y una posición donde lanzarlo.
    private bool LanzarRaycast(Vector2 direccion, Vector2 position)
    {
        Collider2D collider = Physics2D.Raycast(position, direccion, rayDist).collider; // Creamos el collider para el raycast lanzado, en la posición, dirección y con la longitud que queremos.
        return (collider != null && collider.gameObject.layer == LayerMask.NameToLayer("Pelusas")); // Devolvemos si el raycast ha golpeado y si lo que ha golpeado está en la capa pelusas.
    }

    // Función que lanzará el raycast hacia arriba. 
    private bool LanzarRaycastArriba()
    {
        // Devuelve el valor de la función anterior a partir del collider del personaje por la parte superior del mismo. 
        return LanzarRaycast(Vector2.up, new Vector2(transform.position.x, (transform.position.y + gameObject.GetComponent<Collider2D>().bounds.size.y / 2 + 0.1f)));
    }

    // Función que lanzará el raycast hacia la derecha. 
    private bool LanzarRaycastDerecha()
    {
        // Devuelve el valor de la función anterior a partir del collider del personaje por la parte derecha del mismo.
        return LanzarRaycast(Vector2.right, new Vector2(transform.position.x + gameObject.GetComponent<Collider2D>().bounds.size.x / 2 + 0.1f, transform.position.y));
    }

    // Función que lanzará el raycast hacia abajo.
    private bool LanzarRaycastAbajo()
    {
        // Devuelve el valor de la función anterior a partir del collider del personaje por la parte inferior del mismo.
        return LanzarRaycast(Vector2.down, new Vector2(transform.position.x, (transform.position.y - gameObject.GetComponent<Collider2D>().bounds.size.y / 2 - 0.1f)));
    }

    // Función que lanzará el raycast hacia la izquierda.
    private bool LanzarRaycastIzquierdo()
    {
        // Devuelve el valor de la función anterior a partir del collider del personaje por la parte izquierda del mismo.
        return LanzarRaycast(Vector2.left, new Vector2((transform.position.x - gameObject.GetComponent<Collider2D>().bounds.size.x / 2 - 0.1f), transform.position.y));
    }

    // Función que almacenará el resultado de que raycast han impactado y llamará a la función para cambiar los sprites pasándole el array con estos booleanos.
    private void LanzarRaycastsAlrededor()
    {
        alrededorPelusas[(int)Direccion.Arriba] = LanzarRaycastArriba(); // Almacena si el raycast superior ha impactado en el valor concreto del array. 
        alrededorPelusas[(int)Direccion.Derecha] = LanzarRaycastDerecha(); // Almacena si el raycast derecho ha impactado en el valor concreto del array. 
        alrededorPelusas[(int)Direccion.Abajo] = LanzarRaycastAbajo(); // Almacena si el raycast inferior ha impactado en el valor concreto del array. 
        alrededorPelusas[(int)Direccion.Izquierda] = LanzarRaycastIzquierdo(); // Almacena si el raycast izquierdo ha impactado en el valor concreto del array. 

        CambiarSprites(alrededorPelusas); // Llama a la función que cambia los sprites pasándole el array que tiene la información de si los raycast han impactado o no. 
    }

    // Función que recorre todos los hijos de un padre, para que estos sigan lanzando sus raycast después de estar unidos.
    private void RevisarPelusasHijas() 
    {
        for (int i = 0; i < transform.parent.transform.childCount; i++) // Bucle que recorre los hijos, desde 0 hasta el número máximo de hijos. 
        {
            transform.parent.GetChild(i).GetComponent<UnionPelusas>().LanzarRaycastsAlrededor(); // Llama a la función de lanzar raycast en cada hijo. 
        }
    }

    // Función que controla las colisiones. 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Pelusas")) // Si el objeto que nos ha golpeado está en la capa pelusas...
        {
            if (col.transform.parent == null &&
                col.gameObject.GetComponent<UnionPelusas>() != null &&
                !col.gameObject.GetComponent<UnionPelusas>().pelusaUnida) // Si además este objeto no tiene padre, tiene el script de unión y no está unida...
            {
                if (rb != null ) // Si además aún tiene rigidbody...
                {
                    // Comienza la primera unión entre las pelusas.
                    IniciarUniones(); // Llama a la función que controla la primera unión. 
					CuentaPelusas.contadorPelusas--; // Accede a la variable que cuenta pelusas para poder completar niveles, restándole 1, ya que ahora no son 2 pelusas, si no 1.
                    //Debug
                    Debug.Log (CuentaPelusas.contadorPelusas);
                }
         
                UnirPelusa(col); // Llama a la función que une las pelusas, pasándole el gameObject que ha colisionado. 
                LanzarRaycastsAlrededor(); // Llama a la función que controla los raycast y los cambios de sprites.
				CuentaPelusas.contadorPelusas--; // Resta 1 de la variable para completar el nivel.
                col.transform.position = new Vector3(Mathf.Round(col.transform.position.x), Mathf.Round(col.transform.position.y), 0); // Vuelve las coordenadas del objeto que ha colisionado exactas,
                                                                                                                                       // haciendo que se ajuste a las casillas del fondo.
                transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0); // Vuelve las coordenadas del objeto que ha sido colisionado exactas,
                                                                                                                           // haciendo que se ajuste a las casillas del fondo.
                transform.gameObject.tag = "Unido"; // Añade el tag unido a la pelusa que ha sido colisionada.
            }
            else
            {
                if (transform.parent != null) // Si ya tiene un padre...
                {
                    transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Frena la pelusa. 
                }     
            }
            RevisarPelusasHijas(); // Llama a la función que controla que los hijos sigan lanzando los raycast.
        }
    }

    // Función que une dos pelusas. Le pasamos la información del objeto que ha colisionado. 
    void UnirPelusa(Collision2D col)
    {
        Destroy(col.gameObject.GetComponent<Rigidbody2D>()); // Destruye su rigidbody, para que pase a ser controlado por el padre.
        transform.parent = padre.transform; // Hace que el objeto que ha sido colisionado se vuelva hijo. 
        col.transform.parent = padre.transform; //  Hace que el objeto que ha colisionado se vuelva hijo. 
        col.gameObject.GetComponent<UnionPelusas>().pelusaUnida = true; // Activa el estado de pelusa unida del objeto que ha colisionado. 
        col.gameObject.GetComponent<UnionPelusas>().padre = padre; // Hace que el padre del objeto que ha colisionado sea el padre creado en el script.
        padre.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Hace que el padre se quede en el lugar donde han colisionado las pelusas, igualando su velocidad a 0. 
		col.transform.gameObject.tag = "Unido"; // Añade el tag unido a la pelusa que ha colisionado.
    }
}

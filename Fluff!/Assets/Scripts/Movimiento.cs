/* Movimiento.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado en su mayoría por @monchburg (Ramón González)
 * Parte de sonido realizada por @pavel13 (Pablo Jiménez)
 * Comentado por @monchburg (Ramón González)
 * Script que controla el movimiento del personaje
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    // Creación de las variables necesarias para el movimiento.
    Rigidbody2D rb; // Rigidbody del personaje. 
    public float fuerza_movimiento = 5f; // Fuerza con la que el personaje se moverá.
    Vector2 vector_inicio; 
    Vector2 vector_fin;
    Vector2 resta_vector;
	public bool paradaAutomatica = false; 
	public Vector3 vectorParada;
    public bool enMovimiento = false; //  Variable que controla si el personaje está en movimiento o no, si es falsa el jugador podrá mover el personaje. 

    // Creación de la variable para el control de los personajes Confusos.
    public static Vector2 movConfuso;
    
    // Creación de las variables para el control del sonido. 
    public static bool reproduciendoSonido = false;
    public AudioClip sonidoChoque;
    public AudioClip sonidoUnion;
    AudioSource audioCamara;
    AudioSource audioPropio;

    void Start()
    {
        movConfuso = Vector2.zero; // Inicializamos el vector del personaje confuso a 0.
        rb = GetComponent<Rigidbody2D>(); // Añadimos un rigidbody al personaje.
		transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), 0); //Línea que ajusta los personajes a una coordenada exacta.
        audioCamara = Camera.main.gameObject.GetComponent<AudioSource>(); // Añadimos el audio principal a la cámara.
        audioPropio = GetComponent<AudioSource>(); // Añadimos el audio al personaje.
        StartCoroutine(SonidoReposo()); // Hace que la reproducción de sonido no dependa del Update.
    }

    void Update()
    {
        // Las siguientes líneas de código son para hacer una parada de emergencia. 
		if (paradaAutomatica) {
			if (Vector3.Distance(transform.position,vectorParada) < 0.2f) {
				rb.velocity = Vector2.zero;
                enMovimiento = false;
				paradaAutomatica = false;
				transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), 0);
			}
		}

        // Las siguientes líneas sirven para que todos los personajes Confusos se muevan a la vez.
        if (transform.CompareTag("Confuso") && !enMovimiento && movConfuso != Vector2.zero){ // Comparamos si tiene el tag "confuso", si no está en movimiento o si el vector de velocidad es cero. 
            rb.velocity = movConfuso; // Le aplica la misma velocidad del objeto que nosotros hemos movido a los demás personajes confusos.
            enMovimiento = true; 
        }
    }

    // Función que usaremos para mover el personaje. En esta parte detectamos que personaje hemos pulsado.
    private void OnMouseDown()
    {
        if (Input.touchCount > 0) // Si el número de de toques en pantalla es mayor que 0. 
        {
            vector_inicio = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); // Igualamos el vector inicial de posición del personaje a las coordenadas del toque en la cámara de la 
                                                                                        // escena. 
        }
        else
        {
            vector_inicio = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Igual que las líneas anteriores pero para usarlo en pc con la posición del ratón.  
        }
    }

    // Función que usaremos para mover el personaje. En esta parte detectamos cuando se ha soltado el personaje. 
    private void OnMouseUp()
    {
        if (!enMovimiento) { // Si el personaje no está en movimiento.
            if (Input.touchCount > 0) // Y si el número de toques es mayor a 0. 
            {
                vector_fin = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); // Igualamos el vector final de posición del personaje a las coordenadas donde el jugador ha levantado el dedo.
                CalculaVector(); // Llamamos a la función CalculaVector para ver hacia que posición se moverá el personaje. 
            }
            else
            {
                vector_fin = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Igual que las líneas anteriores pero para usarlo en pc. 
                CalculaVector();
            }
        }

    }

    // Función que calculará un vector que dependiendo de si la coordenada más grande es la X o la Y (en sentido positivo o negativo) moverá al personaje hacia una dirección u otra.
    void CalculaVector()
    {
        resta_vector = vector_fin - vector_inicio; // Resta los dos vectores anteriormente calculados para calcular la dirección en la que se moverá el personaje. 
        if (Mathf.Abs(resta_vector.y) > Mathf.Abs(resta_vector.x)) // Compara las coordenadas X e Y del vector resta en valor absoluto. En este caso veremos el movimiento en el eje Y, ya que esta es 
                                                                   // mayor en este caso.
        {
            if (resta_vector.y > 0) // Este condicional lo usaremos para determinar el signo en el eje Y y así mover el personaje hacia arriba o hacia abajo.
            {
                rb.velocity = (Vector2.up * fuerza_movimiento); // Empuja el personaje hacia arriba.
            }
            else
            {
                rb.velocity = (Vector2.up * -fuerza_movimiento); // Empuja el personaje hacia abajo. 
            }
        }
        if (Mathf.Abs(resta_vector.y) < Mathf.Abs(resta_vector.x))// Compara las coordenadas X e Y del vector resta en valor absoluto. En este caso veremos el movimiento en el eje X, ya que esta es 
                                                                  // mayor en este caso.
        {
            if (resta_vector.x > 0) // Este condicional lo usaremos para determinar el signo en el eje X y así mover el personaje hacia la derecha o hacia la izquierda.
            {
                rb.velocity = (Vector2.right * fuerza_movimiento); // Empuja el personaje hacia la derecha.
            }
            else
            {
                rb.velocity = (Vector2.right * -fuerza_movimiento); // Empuja el personaje hacia la izquierda.
            }
        }

        enMovimiento = true;

        // Las siguientes líneas sirven para que todos los personajes Confusos se muevan a la vez.
        if (transform.CompareTag("Confuso") && movConfuso == Vector2.zero) // Comprobamos si el tag es Confuso y si su vector de velocidad es 0.
        {
            movConfuso = rb.velocity; // Le aplicamos a los personajes confusos la misma velocidad que el personaje que hemos movido.
            enMovimiento = true;
        }
    }

    // Función que gestiona las colisiones de los personajes
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Límite")) // Si el personaje choca con un límite del escenario...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia el nivel que se está jugando. 
        }

        enMovimiento = false; // Desactiva el booleano para que pueda volver a moverse.
        if (rb) rb.velocity = Vector2.zero; // Si tiene un rigidbody, cambia su velocidad a 0. 

        if (transform.parent != null) // Si la pelusa no tiene un padre...
        {
            transform.parent.GetComponent<Movimiento>().enMovimiento = false; // Nos aseguramos de que el booleano del padre esté en falso para que pueda moverse. 
            transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Frenamos al padre para que no se desplace. 
        }
        else {
            GetComponent<Movimiento>().enMovimiento = false; 
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        movConfuso = Vector2.zero; // Frena a todos los personajes de tipo confuso al colisionar con algo. 

        audioCamara.clip = sonidoChoque; // Reproduce el sonido de choque de las pelusas.
        audioCamara.Play(); // Reproduce el sonido de fondo. 
    }

    // Activa la parada automática del personaje.
	public void MoveryParar(Vector3 parada){
		paradaAutomatica = true;
		vectorParada = parada;
	}

    // Función que controlará el sonido de los personajes. 
    IEnumerator SonidoReposo()
    {
        while (true)
        {
            if (!reproduciendoSonido) // Si no se está reproduciendo el sonido en reposo...
            {
                audioPropio.Play(); // Reproduce el sonido.
                reproduciendoSonido = true; // Hace que el bucle siga activo.
                yield return new WaitForSeconds(audioPropio.clip.length); // Espera la duración del clip para que se vuelva a reproducir. 
                reproduciendoSonido = false; // Hace que salga del bucle.
            }
            yield return new WaitForSeconds(Random.Range(5, 10)); // Espera un tiempo aleatorio para volver a reproducir el sonido.
        }
    }
}

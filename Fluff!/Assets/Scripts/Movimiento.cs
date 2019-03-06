using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    Rigidbody2D rb;
    public static bool reproduciendoSonido = false;
    public float fuerza_movimiento = 5f;
    Vector2 vector_inicio;
    Vector2 vector_fin;
    Vector2 resta_vector;
	public bool paradaAutomatica = false;
	public Vector3 vectorParada;
    public static Vector2 movConfuso;
    public bool enMovimiento = false;

    
    public AudioClip sonidoChoque;
    public AudioClip sonidoUnion;

    AudioSource audioCamara;
    AudioSource audioPropio;

    void Start()
    {
        movConfuso = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
		transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), 0);
        audioCamara = Camera.main.gameObject.GetComponent<AudioSource>();
        audioPropio = GetComponent<AudioSource>();
        StartCoroutine(SonidoReposo());
    }

    void Update()
    {
        Debug.Log(movConfuso);
		if (paradaAutomatica) {
			if (Vector3.Distance(transform.position,vectorParada) < 0.2f) {
				rb.velocity = Vector2.zero;
                enMovimiento = false;
				paradaAutomatica = false;
				transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), 0);
			}
		}

        if (transform.CompareTag("Confuso") && !enMovimiento && movConfuso != Vector2.zero){
            rb.velocity = movConfuso;
        }




    }

    private void OnMouseDown()
    {
        if (Input.touchCount > 0)
        {
            vector_inicio = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
        {
            vector_inicio = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if (!enMovimiento) { 
            if (Input.touchCount > 0)
            {
                vector_fin = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                CalculaVector();
            }
            else
            {
                vector_fin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CalculaVector();
            }
        }

    }

    void CalculaVector()
    {
        resta_vector = vector_fin - vector_inicio;
        if (Mathf.Abs(resta_vector.y) > Mathf.Abs(resta_vector.x))
        {
            if (resta_vector.y > 0)
            {
                rb.velocity = (Vector2.up * fuerza_movimiento);
            }
            else
            {
                rb.velocity = (Vector2.up * -fuerza_movimiento);
            }
        }
        if (Mathf.Abs(resta_vector.y) < Mathf.Abs(resta_vector.x))
        {
            if (resta_vector.x > 0)
            {
                rb.velocity = (Vector2.right * fuerza_movimiento);
            }
            else
            {
                rb.velocity = (Vector2.right * -fuerza_movimiento);
            }
        }
        enMovimiento = true;
        if (transform.CompareTag("Confuso") && movConfuso == Vector2.zero)
        {
            movConfuso = rb.velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Sonido Choque");
        audioCamara.clip = sonidoChoque;
        audioCamara.Play();

        if (col.gameObject.CompareTag("Límite"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        enMovimiento = false;
        rb.velocity = Vector2.zero;
        movConfuso = Vector2.zero;
    }

	public void MoveryParar(Vector3 parada){
		paradaAutomatica = true;
		vectorParada = parada;
	}

    IEnumerator SonidoReposo()
    {
        while (true)
        {
            if (!reproduciendoSonido)
            {
                Debug.Log("Reposo:"+transform.name);
                audioPropio.Play();
                reproduciendoSonido = true;
                yield return new WaitForSeconds(audioPropio.clip.length);
                reproduciendoSonido = false;
               
            }
            yield return new WaitForSeconds(Random.Range(5, 10));

        }

    }
}

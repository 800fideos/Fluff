/* GameManager.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez) y @pavel13 (Pablo Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla el audio del juego
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
	public static GameManager instance = null; //Un static de este script que es nulo

    public AudioClip MenuPrincipal; //esta variable y las siguientes crean los clips de audio que corresponden a cada mundo y este en concreto al menú principal
    public AudioClip Desvan;
    public AudioClip Salon;
    public AudioClip Baño;
    public AudioClip Cocina;
    public AudioClip Jardin;

    private AudioSource audioSource; //Crea una variable de Audiosource


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //Inicializa la variable Audiosource
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void Awake(){ //Esta función reproduce la música constatemente en todas las escenas sin qu se destruya cuando se carga una nueva
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

    public void CambiarCancion(int nivel) //esta función cambia las canciones entre escenas principales, detiene el audiosource actual e inicia otro en función de que escena sea
    {
        audioSource.Stop();
        if (nivel == 1) //MenuPrincipal
        {
            audioSource.volume = 0.200f;
            audioSource.clip = MenuPrincipal;
        }
        else if (nivel == 2) //Desván
        {
            audioSource.volume = 1f;
            audioSource.clip = Desvan;
        }
        else if (nivel == 3) //Salon
        {
            audioSource.volume = 0.300f;
            audioSource.clip = Salon;
        }
        else if (nivel == 4) //Baño
        {
            audioSource.volume = 0.300f;
            audioSource.clip = Baño;
        }
        else if (nivel == 5) //Cocina
        {
            audioSource.volume = 0.300f;
            audioSource.clip = Cocina;
        }
        else if (nivel == 6) //Jardin
        {
            audioSource.volume = 0.300f;
            audioSource.clip = Jardin;
        }
        else
        {
            Debug.LogError("No hay canción!!!!!!!!!!!!!!!!");
        }
        audioSource.Play();

    }


}

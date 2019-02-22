using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

    public AudioClip MenuPrincipal;
    public AudioClip Desvan;
    public AudioClip Salon;
    public AudioClip Baño;
    public AudioClip Cocina;
    public AudioClip Jardin;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

    public void CambiarCancion(int nivel)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

    public AudioClip MenuPrincipal;
    public AudioClip Desvan;

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
        else 
        {
            Debug.LogError("No hay canción!!!!!!!!!!!!!!!!");
        }
        audioSource.Play();

    }


}

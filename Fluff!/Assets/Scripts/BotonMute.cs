using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonMute : MonoBehaviour
{
	public Sprite OffMusica;
	public Sprite OnMusica;
	public Sprite OffSonido;
	public Sprite OnSonido;
	public Button butMusic;
	public Button butSonido;
	bool isMute;
	public static BotonMute instance = null;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	void Awake(){//Esta función nos permite instanciar la música para evitar que deje de sonar en escenas posteriores
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void MuteMusica (){//Con esta función manejamoslos sprites del botón
		if (butMusic.image.sprite == OnMusica){//Aquí indicamos que si ocurre esto el sprite cambia. Esto luego lo meteremos en el Onclick del botón para que haga el cambio
			
			butMusic.image.sprite = OffMusica;
		}
		else
			butMusic.image.sprite = OnMusica;//Y aquí indicamos que si pasa otra cosa diferente se mantiene el que tiene por defecto
	}

	public void MuteSonido (){ //esta función y sus subsiguientes líneas hacen lo mismo que la anterior pero para otro botón
		if (butSonido.image.sprite == OnSonido) {

			butSonido.image.sprite = OffSonido;
		} else
			butSonido.image.sprite = OnSonido;

	}

	public void Mute (){//esta función silencia la música
		isMute = !isMute;
		AudioListener.volume = isMute ? 0 : 1;
	}
}

/* BotónMute.cs
 * 19/03/2019
 * Versión: 0.3
 * Realizado por @Viejastirpe (Daniel Jiménez)
 * Comentado por @Viejastirpe (Daniel Jiménez)
 * Script que controla las funciones del boton de silenciar el sonido.
 * 
 * */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonMute : MonoBehaviour
{
	public Sprite OffMusica; //Genera la variable de un sprite offmusica
	public Sprite OnMusica; //Genera la variable de un sprite onmusica
    public Sprite OffSonido;//Genera la variable de un sprite offsonido
    public Sprite OnSonido; //Genera la variable de un sprite onsonido
    public Button butMusic; //Genera la variable de un botón de música
	public Button butSonido; //Genera la variable de un botón de sonido
    bool isMute; //Crea un booleano para indicar que el sonido está quitado
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

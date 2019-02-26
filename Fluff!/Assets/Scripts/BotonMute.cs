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
	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void MuteMusica (){
		if (butMusic.image.sprite == OnMusica){
			
			butMusic.image.sprite = OffMusica;
		}
		else
			butMusic.image.sprite = OnMusica;
	}

	public void MuteSonido (){
		if (butSonido.image.sprite == OnSonido) {

			butSonido.image.sprite = OffSonido;
		} else
			butSonido.image.sprite = OnSonido;

	}

	public void Mute (){
		isMute = !isMute;
		AudioListener.volume = isMute ? 0 : 1;
	}
}

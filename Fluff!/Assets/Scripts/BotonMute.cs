using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonMute : MonoBehaviour
{
	public Sprite OffSprite;
	public Sprite OnSprite;
	public Button but;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ChangeImage(){
		if (but.image.sprite == OnSprite)
			but.image.sprite = OffSprite;
		else {
			but.image.sprite = OnSprite;
		}
	}
}

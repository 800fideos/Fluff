using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cono : MonoBehaviour
{
	public bool paradaAutomatica = false;
	Vector3 vectorParada;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (paradaAutomatica) {
			if (Vector3.Distance (transform.position, vectorParada) < 0.1f) {
				paradaAutomatica = false;
				transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), 0);
			} else {
				transform.position = Vector3.Lerp (transform.position, vectorParada, Time.deltaTime);
			}
		}
    }

	public void MoveryParar(Vector3 direccion){
		paradaAutomatica = true;
		vectorParada = transform.position + direccion;
	}
}

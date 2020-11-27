using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mini_Covid : MonoBehaviour
{
	float radio;
	Vector2 direccion;
	float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed =2.0f;
    	radio = transform.localScale.x/2;
        direccion = Vector2.one.normalized; //dirección de 45°
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion*speed*Time.deltaTime);

                //restricción del limite superior
        if(transform.position.y > 13.5 - radio && direccion.y >0){
        	direccion.y = -direccion.y;
        }

        //restricción del limite inferior
        if(transform.position.y < 0 + radio && direccion.y < 0){
        	direccion.y = -direccion.y;
        }

        //derectar si el jugador de la derecha perdio
        if(transform.position.x > 20 - radio  && direccion.x > 0){
        	direccion.x = -direccion.x;

        }

        //derectar si el jugador de la izquierda perdio
        if(transform.position.x < 0.6 + radio  && direccion.x < 0){
 			direccion.x = -direccion.x;
        }
 
    }

    void OnTriggerEnter(Collider other)
    {
          
        if (other.gameObject.tag == "Bloque" || other.gameObject.tag == "BloqueInfectado")
        {
            direccion.y = -direccion.y;
        }
        if (other.gameObject.tag == "Doctor")
        {
            Debug.Log("Perdiste...!");

            Application.LoadLevel("GameOver");

        }

         
    }

}

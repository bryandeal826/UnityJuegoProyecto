using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_mov : MonoBehaviour
{
	float speed;
	Vector2 direccion;
	float Vertical;
	float x,y,z;
	int bandera;
	public GameObject BloqueInfectado;
    // Start is called before the first frame update
    void Start()
    {
       speed=0.9f;
       bandera= 0;
  
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.z <6 && bandera == 0 ){
            z = (speed * Time.deltaTime);
            transform.Translate(x, y, z);
        }
        else {

            bandera = 1;
            z = -(speed * Time.deltaTime);


            if (transform.position.z <= 2)
            {
                bandera = 0;
            }
            transform.Translate(x, y, z);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MiniCovid")
        {
            Instantiate(BloqueInfectado, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}

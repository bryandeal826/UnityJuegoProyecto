using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desinfectante : MonoBehaviour
{
    public GameObject doctor;
    private Transform doctorTrans;

    private Rigidbody2D DesinfectanteRB;

    // Start is called before the first frame update

    void Awake()
    {

        doctor = GameObject.FindGameObjectWithTag("Doctor");
        doctorTrans = doctor.transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (doctorTrans.localScale.x > 0)
        {
            Vector3 dir = new Vector3(5, 5, 0);
            transform.Translate(dir * Time.deltaTime);

        }
        else
        {
            Vector3 dir = new Vector3(-5, 5, 0);
            transform.Translate(dir * Time.deltaTime);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BloqueInfectado" || other.gameObject.tag == "Bloque" || other.gameObject.tag == "Piso" || other.gameObject.tag == "Pared")
        {
            Destroy(gameObject);
        }

    }
}

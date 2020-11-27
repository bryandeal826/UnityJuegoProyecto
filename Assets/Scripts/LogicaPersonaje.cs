using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    //Para limitar al personaje en el eje horizontal
    private Transform theTransform;
    public Vector2 Hrange = Vector2.zero;



    private Rigidbody doctorRB;


    public float speed;

    public float velocidadMovimiento = 5.0f;
  
    private Animator anim;

    //public Rigidbody rb;
    public float fuerzaDeSalto = 2.0f;
    public bool puedoSaltar;

    public GameObject Desinfectante;
    public Transform Origen_Desinfectante;


    public GameObject sonidoMain;
    public GameObject sonidoSalto;

    //Secuencua de animacion de agacharse
    public float velocidadInicial;
    public float velocidadAgachado;

    void LateUpdate()
    {
        theTransform.position = new Vector3(
            Mathf.Clamp(transform.position.x, Hrange.x, Hrange.y),
            transform.position.y,
            transform.position.z
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        //Aumentar los FPS
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;

        doctorRB = GetComponent<Rigidbody>();
        puedoSaltar = false;
        anim = GetComponent<Animator>();
        Instantiate(sonidoMain);


        theTransform = GetComponent<Transform>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
    }


    // Update is called once per frame
    void Update()
    {


        PlayerMovement();

        Dispara_Desinfectante();

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("salte", true);
                doctorRB.AddForce(new Vector3(0,fuerzaDeSalto,0), ForceMode.Impulse);
                Instantiate(sonidoSalto);

            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("agachado", true);
                velocidadMovimiento = velocidadAgachado;

            }

            else
            {
                anim.SetBool("agachado", false);
                velocidadMovimiento = velocidadInicial;
            }

            anim.SetBool("tocosuelo", true);

        }
        else
        {
            EstoyCayendo();
        }
    }



    public void EstoyCayendo()
    {
        anim.SetBool("tocosuelo", false);
        anim.SetBool("salte", false);

    }

    public void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //if(Input.GetKeyDown(KeyCode.A))
        if (horizontal > 0)
        {
            transform.Translate(speed * horizontal * Time.deltaTime,0, 0);

            //doctorRB.velocity = new Vector3();
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (horizontal < 0)
        {


            transform.Translate(speed * horizontal * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetFloat("VelX", Mathf.Abs(horizontal));
   
    }

    public void Dispara_Desinfectante()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Desinfectante, Origen_Desinfectante.position, Origen_Desinfectante.rotation);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pocion")
        {
            Destroy(other.gameObject);
        }
    }

}

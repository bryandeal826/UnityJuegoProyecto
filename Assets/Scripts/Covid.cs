using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid : MonoBehaviour
{
    public GameObject personaje;
    public GameObject pocionA;
    public GameObject pocionB;
    public GameObject BarraHP;
    public int Vida;
    public int VidaMax;
    public GameObject sonidoItem;

    //estado=1 significa que las pociones siguen en el escenario
    //estado=0 significa que las pociones ya fueron cogidas
    private int estadoPocionA = 1;
    private int estadoPocionB = 1;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (pocionB == null && estadoPocionB == 1)
        {
            Instantiate(sonidoItem);
            Vida = Vida - 50;
            Destroy(pocionB);
            float z = (float)Vida / (float)VidaMax;
            Vector3 ScaleBar = new Vector3(1, 1, z);
            BarraHP.transform.localScale = ScaleBar;
            estadoPocionB = 0;
        }
        if (pocionA == null && estadoPocionA == 1)
        {
            Instantiate(sonidoItem);
            Vida = Vida - 50;
            Destroy(pocionA);
            float z = (float)Vida / (float)VidaMax;
            Vector3 ScaleBar = new Vector3(1, 1, z);
            BarraHP.transform.localScale = ScaleBar;
            estadoPocionA = 0;
        }
        if (Vida == 0)
        {
            Debug.Log("Covid muerto!");
            Application.LoadLevel("Victoria");
            
        }
    }



}
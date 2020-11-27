using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo iniciar en Segundos")]
    public int tiempoinicial;
    [Tooltip("Escala del Tiempo del Reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    private Text myText;
    private float TiempoFrameConTiempoScale = 0f;
    private float tiempoMostrarEnSegundos = 0F;
    private float escalaDeTiempoPausar, escalaDeTiempoInicial;
    private bool EstaPausado = false;

    public static int minutos;
    public static int segundos;

    void Start()
    {
        //Escala de Tiempo Original
        escalaDeTiempoInicial = escalaDeTiempo;


        myText = GetComponent<Text>();
        tiempoMostrarEnSegundos = tiempoinicial;

        ActualizarReloj(tiempoinicial);
    }

    // Update is called once per frame
    void Update()
    {

        TiempoFrameConTiempoScale = Time.deltaTime * escalaDeTiempo;
        tiempoMostrarEnSegundos += TiempoFrameConTiempoScale;
        ActualizarReloj(tiempoMostrarEnSegundos);
    }
    public void ActualizarReloj(float tiempoEnSegundos)
    {
         minutos = 0;
         segundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00"); 
        myText.text = textoDelReloj;
    }

}
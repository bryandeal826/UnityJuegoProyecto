using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiempoRecord : MonoBehaviour
{
    private Text myText;
    // Start is called before the first frame update
    void Start()
    {
        int minutos = Reloj.minutos;
        int segundos = Reloj.segundos;
        string textoDelReloj;
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00"); 
        myText = GetComponent<Text>();
        myText.text = textoDelReloj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bloque_infectado : MonoBehaviour
{
    public GameObject Bloque;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Doctor")
        {
            Debug.Log("Perdio!");
            //SceneManager.LoadScene(0);
            Application.LoadLevel("GameOver");
            
        }

        if (other.gameObject.tag == "Desinfectante")
        {
            Instantiate(Bloque, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

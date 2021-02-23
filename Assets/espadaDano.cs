using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espadaDano : MonoBehaviour
{
    public bool atacando_espada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            atacando_espada = true;

        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            atacando_espada = false;

        }
    }
}

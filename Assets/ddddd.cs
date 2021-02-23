using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddddd : MonoBehaviour
{
    public Transform inimigo;
    public bool sae;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  inimigo.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sae = true;
        }
    }
    private  void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sae = false;
        }
    }
}

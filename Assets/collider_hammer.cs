using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_hammer : MonoBehaviour
{
    BoxCollider box;
    public BoxCollider boxmartelo;
    bool empurra;
    void Start()
    {
        box =GetComponent<BoxCollider>();
        empurra = true;
    }

    // Update is called once per frame
    void Update()
    {
        empurra = boxmartelo.GetComponent<BoxCollider>().enabled;
        if (empurra == false)
        {
            box.enabled = true;
        }
        if( empurra == true)
        {
            box.enabled = false;
        }
    }
}

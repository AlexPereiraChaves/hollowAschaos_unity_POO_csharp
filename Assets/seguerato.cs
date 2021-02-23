using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seguerato : MonoBehaviour
{
    public Transform rato;
    public bool atacando;
    public Animator animarato;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rato != null)
        {
            transform.position = rato.position;
        }
        
        
           
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("inimigo"))
        {
            atacando = true;
            animarato.SetBool("atacando", true);
            animarato.SetBool("andando", false);
            Invoke("Falso", 3f);
        }
        
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {
            

            atacando = true;

        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {
            atacando = false;
        }
    }
    void Falso()
    {
        animarato.SetBool("atacando", false);
    }
}

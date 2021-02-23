using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_areadano : MonoBehaviour
{
    float timer;
    public Animator boosanima;
    public danobossnoplayer danboss;
    public Transform bosstrans;
    public bool podelevardano, taescudo, staybate;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
        timer += Time.deltaTime;
        transform.position = bosstrans.position;
      
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player")&& timer>0.1f )
        {
            
            boosanima.SetBool("atacando", true);

            
            timer = 0;
        }
        if (other.gameObject.CompareTag("shild") &&timer >0.1f)
        {
            timer = 0;
            boosanima.SetBool("atacando", true);
            

            taescudo = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        
        
        if (other.gameObject.CompareTag("Player") && timer > 1.4f)
        {
            
            boosanima.SetTrigger("bom");
         
            danboss.tomo = 0f;
           
            timer = 0;
        }
        if (other.gameObject.CompareTag("shild") && timer > 1.4f)
        {
            danboss.tamo = 0f;
            boosanima.SetTrigger("bom");
            timer = 0;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            
            boosanima.SetBool("atacando", false);
           
            danboss.tomo = 0f;
            
        }
        if (other.gameObject.CompareTag("shild") )
        {
            
            boosanima.SetBool("atacando", false);
           
            danboss.tamo = 0f;

        }
    }
    
    public void Pode()
    {
        podelevardano = true;
        
    }
    public void Npode()
    {
        podelevardano = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hammer : MonoBehaviour
{
    public Animator pivo;
    public bool atacando, ataquefraco, ataquemedio,ataqueforte, naotroca;
    BoxCollider Collider;
    public Slider barraGolpe;
    public ParticleSystem max, medio, padrao, maxpequeno,efeitoMax;
    public int ata = 0;
    bool Atacaporra;
   
    void Start()
    {
        Collider = GetComponent<BoxCollider>();
        Collider.enabled = false;

      Atacaporra  = pivo.GetBool("atacando");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse1) && barraGolpe.value != 0 && barraGolpe.value <= 1.4 && barraGolpe.value >= 0)
        {
            
            barraGolpe.value = 0;
            pivo.GetComponent<Animator>().SetBool("atacando", true);
            naotroca = true;
            Invoke("Terra", 0.5f);
            Invoke("Desativa", 0.8f);
            Invoke("Troca", 1.5f);
        }
        if ( !Input.GetKey(KeyCode.Mouse1)&& barraGolpe.value !=0 && barraGolpe.value <= 3&& barraGolpe.value >=1.41)
        {
            ata = 1;
            barraGolpe.value = 0;
            pivo.GetComponent<Animator>().SetBool("atacando", true);
            ataquefraco = true;
            naotroca = true;
            Invoke("Terra", 0.5f);
            Invoke("Desativa", 0.8f);
            Invoke("Troca", 1.5f);
        }
        if (!Input.GetKey(KeyCode.Mouse1) && barraGolpe.value != 0 && barraGolpe.value >=3.01 && barraGolpe.value <4.4)
        {
            ata = 2;
            barraGolpe.value= 0;
            pivo.GetComponent<Animator>().SetBool("atacando", true);
            ataquemedio = true;
            naotroca = true;
            Invoke("Terragrande", 0.5f);
            Invoke("Desativa", 0.8f);
            Invoke("Troca", 1.5f);
        }
        if (!Input.GetKey(KeyCode.Mouse1) && barraGolpe.value != 0 && barraGolpe.value <=5 && barraGolpe.value >4.41)
        {
            ata = 3;
            barraGolpe.value = 0;
            pivo.GetComponent<Animator>().SetBool("atacando", true);
            ataqueforte = true;
            naotroca = true;
            Invoke("Efeitomax", 0.5f);
            Invoke("Desativa", 0.8f);

            Invoke("Troca", 1.5f);
        }
       
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& !Input.GetKey(KeyCode.Mouse1) &&! Input.GetKeyDown(KeyCode.Mouse1))
        {
            pivo.GetComponent<Animator>().SetBool("atacando", true);
            Collider.enabled = true;
            Invoke("Terra", 0.5f);
            naotroca = true;
            Invoke("Troca", 1.5f);
            Invoke("Desativa", 0.8f);
        }
       
        
        
        
        
    }
  
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag( "inimigo"))
        {
            atacando = true;
           
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            atacando = false;

        }
    }
    void Terra()
    {
        padrao.Play();
    }
    void Terragrande()
    {
        medio.Play();
    }
    void Efeitomax()
    {
        efeitoMax.Play();
    }
    void Desativa()
    {
       pivo.GetComponent<Animator>().SetBool("atacando", false);
       ata = 0;
    }
    public void Troca()
    {
        naotroca = false;
    }
}

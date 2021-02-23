using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dano_forte : MonoBehaviour
{
    bool isalcance, isalcance_shild;
    public MeshRenderer aviso;
    public GameObject espada;
    float timer, tomo;
    float tempoentre = 2f;
    public player_script pas;
    public shild_live pass;
    public ddddd a;
    
    // Start is called before the first frame update
    void Awake()
    {
        aviso.enabled = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        tomo += Time.deltaTime;
        if (isalcance == true && timer >= tempoentre && isalcance_shild == false)
        {
            timer = 0;

            pas.LevaDano(20);
        }
        if (a.sae ==true && tomo > 4f)
        {
            tomo = 0;
            aviso.enabled = true;

             Invoke("Atacar", 1.5f);

        }
        if (isalcance_shild == true && timer >= tempoentre)
        {
            timer = 0;

           pass.LevaDano(20);
        }else
        {
            isalcance_shild = false;
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isalcance = true;


        }
        if (other.gameObject.CompareTag("shild"))
        {
            isalcance_shild = true;
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isalcance = false;
        }
        if (other.gameObject.CompareTag("shild"))
        {
            isalcance_shild = false;
        }
       
    }
    void Atacar()
    {
        espada.GetComponent<Animator>().SetTrigger("Ataque");
        aviso.enabled = false;
    }
    
}

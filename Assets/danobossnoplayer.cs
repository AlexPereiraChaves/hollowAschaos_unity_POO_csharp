using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danobossnoplayer : MonoBehaviour
{
    public player_script player;
    public boss_areadano boss;
    public Transform bosspos;
    public float timer, Z, X, tamo, tomo;
    public Rigidbody rigidy;
    public Animator bossanima;
    public shild_live shild;
    public bool entrouantes;
    public bool empurre;
    bool shildarea;
    public bool bateu;
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = bosspos.position;
        if (tamo >= 1.8f)
        {
            player.empurre = true;
            shild.LevaDano(20);
            tamo = 0f;
        }
        if (tomo >= 1.8f)
        {

                bateu = true;
                Invoke("Tafalso", 0.1f);
                player.LevaDano(20);
                tomo = 0f;
        }
        
        
           
            
    }
    public void OnTriggerEnter(Collider other)
    {
       
    }
       public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("shild"))
            {
                shildarea = true;
                tamo += Time.deltaTime;
            }


            if (other.gameObject.CompareTag("Player") && shildarea == false)
            {
                tomo += Time.deltaTime;
            }
            else { shildarea = false; }
           
        }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tomo = 0f;
        }
        if (other.gameObject.CompareTag("shild"))
        {
            tamo = 0f;
        }
    }
    void Jar()
        {
            player.LevaDano(20);
        }
        void Jarr()
        {
            shild.LevaDano(20);
        }
        void Tafalso()
        {
            bateu = false;
        }
       public  void Bati()
        {
            bateu = true;
        }
    
}

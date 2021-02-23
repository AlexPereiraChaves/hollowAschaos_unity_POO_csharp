using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoinimigoespada : MonoBehaviour
{
    bool tanoalcance;
    public bool isalcance, isalcance_shild;
    
    float timer;
    float tempoentre = 2f;
    public player_script pas;
    public shild_live pass;
   

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        
        if (isalcance == true && timer >= tempoentre && isalcance_shild == false)
        {
            timer = 0;

            pas.LevaDano(20);
        }
        if (isalcance_shild == true && timer >= tempoentre)
        {
            timer = 0;

            pass.LevaDano(20);
        }
        else
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
}

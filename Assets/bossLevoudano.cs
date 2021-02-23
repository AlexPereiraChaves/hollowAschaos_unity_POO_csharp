using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossLevoudano : MonoBehaviour
{
    public boss_script boss;
    float timer, timinho;
    public hammer hammer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timinho += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("magico") && timer>1)
        {
           
            if(hammer.ata== 0)
            {
            boss.Levoudano(10);
            timer = 0;
            }
            if(hammer.ata == 1)
            {
                boss.Levoudano(20);
            }
            if (hammer.ata==2)
            {
                boss.Levoudano(25);
            }
            if (hammer.ata == 3)
            {
                boss.Levoudano(30);
            }
        }
       
        if (other.gameObject.CompareTag("espada") && timer >1)
        {
            boss.Levoudano(20);
            timer = 0;
          
        }
        if (other.gameObject.CompareTag("ajudante") && timinho>2)
        {
            timinho = 0;
            boss.Levoudaninho(2);
        }


    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areadanosuper : MonoBehaviour
{
    public player_script player;
    public shild_live shield;
    bool sas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("shild"))
        {
            sas = true;
            shield.LevaDano(30);
        }
        if (other.gameObject.CompareTag("Player") && sas == false)
        {
            player.LevaDano(10);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("shild"))
        {
            sas = false;
            
        }
    }

}

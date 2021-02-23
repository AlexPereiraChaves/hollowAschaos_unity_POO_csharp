using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danobala : MonoBehaviour
{
    public player_script pas;
    public shild_live pass;
  
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
        if (other.gameObject.CompareTag("Player"))
        {
            pas.LevaDano(10);
            
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("shild"))
        {
            pass.LevaDano(20);
            Destroy(gameObject);
        }
        
    }

}

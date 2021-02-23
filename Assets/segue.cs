using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segue : MonoBehaviour
{
    public Transform ca;
    public Enemy_forte bla;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bla.jul == false)
        {
        transform.position = ca.position;
        }
      
        
    }
}

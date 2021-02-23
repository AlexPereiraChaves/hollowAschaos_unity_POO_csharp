using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sea : MonoBehaviour
{
    public Transform palyer;
    public boss_script bos;
    public player_script dan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = palyer.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Demon Blade Lord" && bos.atacados== true) {
            dan.LevaDano(30);

        } ;
    }
}

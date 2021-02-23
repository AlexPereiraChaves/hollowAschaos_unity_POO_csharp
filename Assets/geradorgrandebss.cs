using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorgrandebss : MonoBehaviour
{
    public player_script player;
    public shild_live shield;
    bool sas;
    public ParticleSystem deaht;
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
            deaht.transform.position = transform.position;
            deaht.Play();
        }
        if (other.gameObject.CompareTag("Player") && sas == false)
        {
            player.LevaDano(20);
            deaht.transform.position = transform.position;
            deaht.Play();
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

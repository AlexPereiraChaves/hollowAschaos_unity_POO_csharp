using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barlife : MonoBehaviour
{
    
    public Transform bar;
    float vidaamenizada,life;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        life = 0.27f;
    }

    void FixedUpdate()
    {

        bar.LookAt(player);

    }
    public void InformaDano(int amount)
    {
        vidaamenizada = amount;
        if (vidaamenizada == 10)
        {
            life = 0.018f;
        }
        if (vidaamenizada == 20)
        {
            life = 0.032f;
        }
        if (vidaamenizada == 30)
        {
            life = 0.05f;
        }
        if (vidaamenizada == 50)
        {
            life = 0.07f;
        }
        if (vidaamenizada == 70)
        {
            life = 0.10f;
        }
        if (bar.transform.localScale.x > 0)
        {
            bar.transform.localScale -= new Vector3(life, 0, 0);
        }
        if (bar.transform.localScale.x < 0)
        {
            bar.transform.localScale -= new Vector3(0, 0, 0);
        }
    }
}

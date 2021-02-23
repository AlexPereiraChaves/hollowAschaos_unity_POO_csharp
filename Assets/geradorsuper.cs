using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorsuper : MonoBehaviour
{
    public  Transform areadano;
    public Transform player;
    public ParticleSystem aviso;
    public bool va;
    public int count;
    float timer;
    float paX, paZ;
    Vector3 blin;
    // Start is called before the first frame update

    public void Start()
    {
        aviso.playbackSpeed = 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        if (va == true)
        {
            timer += Time.deltaTime;
            if (count < 10 && timer > 1)
            {
                timer = 0;
                Especial();
            }
        }
    }
    public void Especial()
    {
        
        //====SE FICAR FÁCIL FAZ APENAS BROTAR NO PLAYER;
        float paX = Random.Range(transform.position.x, player.position.x);
        float paZ = Random.Range(transform.position.z, player.position.z);
        Vector3 zas= new Vector3(paX, 0, paZ);
        aviso.transform.position = zas;
        aviso.Play();
        blin = zas;
        Invoke("Ativa",1);
        

    }
    void Ativa()
    {
       areadano.position = blin;
        count += 1;
    }
}

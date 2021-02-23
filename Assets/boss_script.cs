using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class boss_script : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform Player, backdash, frente, boxsuper,longe;
    public Rigidbody ridy;
    public int min, max;
    public Animator anima;
    public ParticleSystem partDash, eltricIdle, daVitoria;
    public geradorsuper setasuper;
    public AudioSource basdas;
    public Image bar;
    public Image foto;
    public GameObject areahit, outraare;
    int animaint;
    public ParticleSystem an, en, on, sin,ataquis;
    bool atacando, atcforte, andando, idle, dashdado;
    public bool atacados;
    int vidaagora = 300, dash;
    float timer;
    public Slider jas;
    public AudioClip musicao;
    public AudioSource source;
    public player_script ppp;
    public Transform ataqueforti;
    void Start()
    {
        source.clip = musicao;
        source.Play();
        jas.gameObject.SetActive(true);
        areahit.SetActive(true);
        outraare.SetActive(true);
        foto.gameObject.SetActive(true);
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
        nav.SetDestination(Player.position);
        anima.SetBool("andando", true);
        an.Play(); en.Play(); on.Play(); sin.Play();
        jas.value = vidaagora;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

       

        if (anima.GetBool("andando") == true )
        {
            nav.SetDestination(Player.position);
        }
    }
    
    void Atacadofoi(bool at)
    {
        nav.enabled = !at;
        anima.SetBool("andando", !at);
       

    }
    public void Levoudano(int amount)
    {
       
        dash = Random.Range(min, max);
        if (dash == 1 && anima.GetBool("atacando") == false)
        {
            Dash();
        }
        if ( dash == 4 || dash == 2 || dash == 6 && atacando== false && anima.GetBool("atacando") == false)
        {
            vidaagora -= amount;
            anima.SetTrigger("hitdamage");
        }
        if (dash == 1 || dash == 3 || dash == 5 && dash == 0 || dash == 4 || dash == 2 || dash == 6 && atacando == true && anima.GetBool("atacando") == true)
        {
            vidaagora -= amount;
            eltricIdle.Play();
        }
        if (dash == 3 || dash == 5 )//&& anima.GetBool("atacando") == false )
        {
            partDash.Play();
            basdas.Play();
            anima.SetTrigger("deudash");
            transform.position = backdash.position;
            Dash();
        }
        if (vidaagora < 220)
        {
         
            if (dash == 2 ||dash == 0)
            {
                atacando = true;
                Atacadofoi(true);
                nav.enabled = false;
                anima.SetBool("super", true);
                setasuper.va = true;
                Invoke("Desetar", 10);
                
            }
        }
        jas.value = vidaagora;
        if (vidaagora <= 0)
        {
            an.Stop(); en.Stop(); on.Stop(); sin.Stop();
            daVitoria.Play();
            anima.SetBool("morreu", true);
            Invoke("Morreu", 2);

        }
    }
    public void Levoudaninho(int amoun)
    {
        vidaagora -= amoun;
        eltricIdle.Play();
        if (vidaagora <= 0)
        {
            daVitoria.Play();
            anima.SetBool("morreu", true);
            Invoke("Morreu", 2);
        }
        jas.value = vidaagora;
    }
   public  void Dash()
    {
        atacando = true;
        Atacadofoi(true);
        anima.SetTrigger("ataqueForte");
        atacados = true;
        AtaqueForte();
       
    }
    void Desetar()
    {
       
      atacando = false;
        Atacadofoi(false);
        nav.enabled = true;
        anima.SetBool("super", false);
        anima.SetBool("atacando", false);
        setasuper.va = false;
        setasuper.count = 0;
        boxsuper.position = longe.position;
    }
    void AtaqueForte()
    {
        transform.position = frente.position;
        atacando = false;
        Atacadofoi(false);
        Invoke("Atacos", 1);
        Invoke("Atacid", 2.5f);
    }
   void Morreu()
    {
        ppp.winzada = true;
        source.Stop();
        areahit.SetActive(false);
        outraare.SetActive(false);
        jas.enabled = false;
        foto.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    public void Atacos()
    {
        
        atacados = false;

    }
   void Atacid()
    {
        ataquis.transform.position = transform.position;
        ataquis.Play();
ataqueforti.position = transform.position;
    }
}
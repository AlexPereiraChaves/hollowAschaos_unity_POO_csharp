using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_forte : MonoBehaviour
{
    bool  minhaarea;
    public bool jul;
    public int min = 0, max = 4,  vidaagora=150,dash;
    float timer, timinho;
    NavMeshAgent nav;
    Transform player;
    Animator anima;
    public ParticleSystem empurrapart;
    public ParticleSystem dashparticle, morteparticle;
    public ParticleSystem hitParticles;
    public Transform volta;
    public GameObject  areamagica,Areadano;
    bool Atacado, AtacadoHammer, AtacadoEspada, espadaanima, hammeranima, Atacadoajudante;
    public hammer ataques;
    public espadaDano espada;
    public bool destruir;
    public Transform areaprotecao, ratopos;
    public segue Segue;
    public AudioSource audo;
    public AudioClip dashsom, hitsom;
    public Animator pivoanimator, espadaanimator;
    public player_script espad;
    public pontuacao pontuacaos;
    public barlife informa;
    public seguerato areaajudante;
    public hammer areahammer;
    public SphereCollider cavcollider;
    public ratoscript Ratoscript;
    void Awake()
    {
        
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anima = GetComponent<Animator>();
        nav.enabled = false;
        dashparticle.playbackSpeed = 6;
       
    }

    // Update is called once per frame
    void Update()
    {
        Atacadoajudante = areaajudante.atacando;
        hammeranima = pivoanimator.GetBool("atacando");
        espadaanima = espadaanimator.GetBool("atacando");
        timer += Time.deltaTime;
        Atacado = areamagica.GetComponent<danomagico>().tanaarea;
        AtacadoHammer = areahammer.atacando;
        //  AtacadoEspada = areaEspada.GetComponent<espadaDano>().atacando_espada;
        AtacadoEspada = espada.atacando_espada;
        
        
            if (Vector3.Distance(transform.position, player.position) < 15)
            {
                nav.enabled = true;
                anima.SetBool("andando", true);
            }
            if (Vector3.Distance(transform.position, player.position) > 20)
            {
                nav.enabled = false;
                anima.SetBool("andando", false);
            }
            if (nav.enabled == true)
            {
                nav.SetDestination(player.position);
            }
        
        if (Vector3.Distance(transform.position, player.position) < 7 && timer > 2f)
        {
            timer = 0;
            dash = Random.Range(min, max);

            if (dash == 1 || dash == 3)
            {
                Vector3 dashtrans = transform.position;
                dashtrans.y = 0.5f;
                dashparticle.transform.position = dashtrans;
                audo.clip = dashsom;
                audo.Play();
                dashparticle.Play();
                float Horizontal = Input.GetAxis("Horizontal");
                float Vertical = Input.GetAxis("Vertical");
                Vector3 ne = new Vector3(Horizontal, 0, Vertical).normalized;
                transform.position += ne * 3;
            }
        }   
    
        if (Atacado == true && timer > 0.5f && minhaarea == true)
        {
            timer = 0;
            Levoudano(10);
            informa.InformaDano(10);
            audo.clip = hitsom;
            audo.Play();
            hitParticles.transform.position = transform.position;
            hitParticles.Play();
        }
        if (AtacadoHammer == true && timer > 1 && minhaarea == true && hammeranima == true)
        {
            
            audo.clip = hitsom;
            audo.Play();
            timer = 0;
            Levoudano(20);
            informa.InformaDano(10);
            hitParticles.transform.position = transform.position;
            hitParticles.Play();
            if (ataques.ataquefraco == true)
            {
                informa.InformaDano(20);
                ataques.ataquefraco = false;
                Levoudano(10);

            }
            if (ataques.ataquemedio == true)
            {
                informa.InformaDano(50);
                ataques.ataquemedio = false;
                Levoudano(30);
            }
            if (ataques.ataqueforte == true)
            {
                informa.InformaDano(70);
                ataques.ataqueforte = false;
                Levoudano(50);
            }
            minhaarea = false;
        }
        if (AtacadoEspada == true && timer > 1 && minhaarea == true && espad.espadaatacando == true)
        {
            timer = 0;
            espad.espadaatacando = false;
            Levoudano(20);
            informa.InformaDano(20);
            audo.clip = hitsom;
            audo.Play();
            hitParticles.transform.position = transform.position;
            hitParticles.Play();
            minhaarea = false;
        }

        if (Atacadoajudante == true && timinho > 2 && minhaarea == true)
        {
            timinho = 0;
            Levoudanoajudante(5);
            informa.InformaDano(10);
        }
    }
    void Levoudano(int amount)
    {
        
            vidaagora -= amount;


        if (vidaagora <= 0)
            {
           
            cavcollider.enabled = false;
            Ratoscript.jasetou = false;
            Ratoscript.inimigoaqui = false;
            pontuacaos.pontos += 50;
            destruir = true;
            morteparticle.Play();
            Destroy(Areadano);
            Segue.enabled = false;
            jul = true;
            areaprotecao.position += new Vector3(100, 0, 0);
            Invoke("Morte", 0.7f);
            }
        
    }
    void Levoudanoajudante(int amount)
    {
        
        vidaagora -= amount;
        Ratoscript.any.transform.position = transform.position;
        Ratoscript.Segueinimigo();
        
        
        if (vidaagora <= 0)
        {
           
            cavcollider.enabled = false;
            Ratoscript.jasetou = false;
            Ratoscript.inimigoaqui = false;
            pontuacaos.pontos += 50;
            destruir = true;
            morteparticle.Play();
            Destroy(Areadano);
            Segue.enabled = false;
            jul = true;
            areaprotecao.position += new Vector3(100, 0, 0);
            Invoke("Morte", 0.7f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("magico"))
        {
            minhaarea = true;
        }
        if (other.gameObject.CompareTag("empurra"))
        {
            Empurrado();

        }
        if (other.gameObject.CompareTag("espada"))
        {
            minhaarea = true;
        }
        if (other.gameObject.CompareTag("ajudante"))
        {
            minhaarea = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("magico"))
        {
            minhaarea = false;
        }
        if (other.gameObject.CompareTag("espada"))
        {
            minhaarea = false;
        }
        if (other.gameObject.CompareTag("ajudante"))
        {
            minhaarea = true;
        }

    }
    void Empurrado()
    {
        empurrapart.transform.position = transform.position;
        empurrapart.Play();
        transform.position = Vector3.Lerp(transform.position, volta.transform.position, 20 * Time.smoothDeltaTime);
    }
    void Morte()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class inimigoMove : MonoBehaviour
{
    public Animator pivo;
    public AudioSource scream;
    public AudioClip hitsom, hitsomprotegido;
    bool minhaarea, protegido ;
    public ParticleSystem empurrapart;
    Transform player;
    public Transform capitao, volta;
    CapsuleCollider bat;
    NavMeshAgent nav;
    public player_script espad;
    int vidaagora = 30;
    public GameObject areamagica;
    public bool Atacadoajudante = false;
    bool Atacado, AtacadoHammer, AtacadoEspada, tacandohammer;
    float timer, tomo, timinho;
    public ParticleSystem hitParticles, protegidoParticle;
    Rigidbody rigidy;
    public hammer ataques;
    public pontuacao pontuacaos;
    public seguerato areaajudante;
    public hammer areahammer;
    public espadaDano areaespada;
    public SphereCollider movcollider;
    public ratoscript Ratoscript;
    
    public seguerato ratosegue;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidy = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false;



    }


    void Update()
    {
        
        Atacadoajudante = areaajudante.atacando;
        tacandohammer = pivo.GetBool("atacando");
        timer += Time.deltaTime;
        tomo += Time.deltaTime;
        timinho += Time.deltaTime;
        Atacado = areamagica.GetComponent<danomagico>().tanaarea;
        AtacadoHammer = areahammer.atacando;
        AtacadoEspada = areaespada.atacando_espada;
        if (Vector3.Distance(transform.position, player.position) < 15)
        {
            nav.enabled = true;
        }

        if (nav.enabled == true)
        {
            nav.SetDestination(player.position);
        }
        
            
        
        if (Atacado == true && timer > 0.5f && minhaarea == true)
        {
            timer = 0;
            Levoudano(10);
        }
        if (AtacadoHammer == true && timer > 2f && minhaarea == true && tacandohammer == true)
        {
            timer = 0;
            Levoudano(20);

            if (ataques.ataquefraco == true && tomo > 0.5f)
            {
                ataques.ataquefraco = false;
                Levoudano(10);

            }
            if (ataques.ataquemedio == true && tomo > 0.5f)
            {
                ataques.ataquemedio = false;
                Levoudano(30);
            }
            if (ataques.ataqueforte == true && tomo > 0.5f)
            {
                ataques.ataqueforte = false;
                Levoudano(50);
            }
        }
        if (AtacadoEspada == true && timer > 1 && minhaarea == true && espad.espadaatacando == true)
        {
            espad.espadaatacando = false;
            timer = 0;
            Levoudano(20);
        }
        if (Atacadoajudante == true && timinho > 2 && minhaarea == true)
        {
            timinho = 0;
            Levoudanoajudante(5);
        }

       
    }

    private void Levoudano(int amount)
    {
        if (protegido == false)
        {
            

               vidaagora -= amount;
            scream.clip = hitsom;
          scream.Play();
            hitParticles.transform.position = transform.position;
           hitParticles.Play();
          
            if (vidaagora <= 0)
            {
                
                movcollider.enabled = false;
                Ratoscript.jasetou = false;
                Ratoscript.inimigoaqui = false;
                pontuacaos.pontos += 5;
                gameObject.GetComponent<Animator>().applyRootMotion = false;
                hitParticles.Play();
                gameObject.GetComponent<Animator>().SetTrigger("morreu");
                Invoke("Morte", 0.5f);
              
            }
        }
        if (protegido == true && capitao != null)
        {
            scream.clip = hitsomprotegido;
            scream.Play();
            protegidoParticle.transform.position = capitao.position;
            protegidoParticle.Play();
            
        }
        
        
    }
    private void Levoudanoajudante(int amount)
    {
       
        if (protegido == false)
        {
            Ratoscript.any.transform.position = transform.position;
            Ratoscript.Segueinimigo();

            vidaagora -= amount;
            
            hitParticles.transform.position = transform.position;
            hitParticles.Play();

            if (vidaagora <= 0)
            {
                Ratoscript.jasetou = false;
                Ratoscript.inimigoaqui = false;
                pontuacaos.pontos += 5;
                gameObject.GetComponent<Animator>().applyRootMotion = false;
                hitParticles.Play();
                gameObject.GetComponent<Animator>().SetTrigger("morreu");
                Invoke("Morte", 0.5f);

            }
        }
        if (protegido == true && capitao != null)
        {
            Ratoscript.any.transform.position = transform.position;
            Ratoscript.Segueinimigo();
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
        if(other.gameObject.CompareTag("espada"))
        {
            minhaarea = true;
        }
        if (other.gameObject.CompareTag("areaProtecao"))
        {
            protegido = true;
            protegidoParticle.Play();
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
        if (other.gameObject.CompareTag("areaProtecao"))
        {
            protegido = false;
            protegidoParticle.Stop();

        }
        if (other.gameObject.CompareTag("ajudante"))
        {
            minhaarea = false;

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

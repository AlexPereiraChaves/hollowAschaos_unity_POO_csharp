using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class atirador : MonoBehaviour
{
    public Animator pivoanimator, espadaanimator;
    public AudioSource audiosas;
    public AudioClip hitsom, hitsomprotegido;
    NavMeshAgent nav;
    public ParticleSystem empurrapart;
    Transform player;
    public Transform capitao, volta;
    bool minhaarea, protegido;
    bool Atacado, AtacadoHammer, AtacadoEspada, espadaanima, hammeranima, Atacadoajudante;
    float timer;
    int vidainicial = 20;
    int vidaagora;
    public GameObject areamagica;
    public CapsuleCollider atiracollider;
    public hammer ataques;
    public ParticleSystem hitParticles,protegidoParticle;
    public player_script espad;
    public pontuacao pontuacaos;
    public seguerato areaajudante;
    public hammer areahammer;
    public espadaDano areaespada;
    public ratoscript Ratoscript;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        vidaagora = vidainicial;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        espadaanima = espadaanimator.GetBool("atacando");
        hammeranima = pivoanimator.GetBool("atacando");
        timer += Time.deltaTime;
        Atacado = areamagica.GetComponent<danomagico>().tanaarea;
        //AtacadoHammer = areaHammer.GetComponent<hammer>().atacando;
        AtacadoHammer = areahammer.atacando;
        // AtacadoEspada = areaEspada.GetComponent<espadaDano>().atacando_espada;
        AtacadoEspada = areaespada.atacando_espada;
        Atacadoajudante = areaajudante.atacando;

        if (Vector3.Distance(transform.position, player.position) < 20  )
        {
                
                transform.LookAt(player);
        }
        

        if (Atacado == true && timer > 1f && minhaarea == true)
        {
            timer = 0;
            Levoudano(10);
        }
        if (AtacadoHammer == true && timer > 5 && minhaarea == true && hammeranima==true)
        {
            timer = 0;
            Levoudano(20);
            if (ataques.ataquefraco == true)
            {
                ataques.ataquefraco = false;
                Levoudano(10);

            }
            if (ataques.ataquemedio == true)
            {
                ataques.ataquemedio = false;
                Levoudano(20);
            }
            if (ataques.ataqueforte == true)
            {
                ataques.ataqueforte = false;
                Levoudano(30);
            }
        }
        if(AtacadoEspada==true && timer> 1 && minhaarea == true && espad.espadaatacando == true)
        {
            espad.espadaatacando = false;
            timer = 0;
            Levoudano(20);
        }
        if(Atacadoajudante== true && timer>1&& minhaarea == true)
        {
            timer = 0;
            Levoudanoajudante(5);
          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("magico"))
        {
            minhaarea = true;
        }
        if (other.gameObject.CompareTag("espada"))
        {
            minhaarea = true;
        }
        if (other.gameObject.CompareTag("empurra"))
        {
            Empurrado();

        }
        if (other.gameObject.CompareTag("areaProtecao"))
        {
            protegido = true; 
        }
        if(other.gameObject.CompareTag("ajudante"))
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
            minhaarea =false;
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
    void Levoudano(int amount)
    {
        if (protegido == false)
        {
            vidaagora -= amount;
            hitParticles.transform.position = transform.position;
            hitParticles.Play();
            audiosas.clip = hitsom;
            audiosas.Play();
            if (vidaagora <= 0)
            {
                
                pontuacaos.pontos += 15;
                hitParticles.Play();
                atiracollider.enabled = false;
                Ratoscript.jasetou = false;
                Ratoscript.inimigoaqui = false;
                gameObject.GetComponent<Animator>().SetTrigger("morreu");
                Invoke("Morte", 0.5f);
                gameObject.GetComponent<Animator>().applyRootMotion = false;

            }
        }
        if (protegido == true && capitao != null)
        {
            audiosas.clip = hitsomprotegido;
            protegidoParticle.transform.position = capitao.position;
            protegidoParticle.Play();
        }
        
            if (capitao = null)
            {
                protegidoParticle.Stop();
            }
        

    }
    void Levoudanoajudante(int amount)
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
                
                pontuacaos.pontos += 15;
                atiracollider.enabled = false;
                Ratoscript.jasetou = false;
                Ratoscript.inimigoaqui = false;
                hitParticles.Play();
                gameObject.GetComponent<Animator>().SetTrigger("morreu");
                Invoke("Morte", 0.5f);
                gameObject.GetComponent<Animator>().applyRootMotion = false;

            }
        }
        if (protegido == true && capitao != null)
        {
            Ratoscript.any.transform.position = transform.position;
            Ratoscript.Segueinimigo();
            
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

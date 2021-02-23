using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ratoscript : MonoBehaviour
{
    public float vidaagora = 200;
    NavMeshAgent ratonav;
    Transform player;
    Transform inimigo;
    public bool jasetou,inimigoaqui;
    public GameObject any;
    public Animator animarato;
    public inimigoMove ajuda;
    public Image ratoimag;
    bool comeca = false;
    float tempo=30;
    public Color cont;
    public ativarato ativ;
    public Image progress;
    public GameObject arearato;
    public bool jafoi;
    int pro;
   
    void Start()
    {
        any.name = "s";
        inimigo = GameObject.FindGameObjectWithTag("inimigo").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ratonav = GetComponent<NavMeshAgent>();
        ratonav.enabled = true;
        ratoimag.enabled = true;
    }
    

    // Update is called once per frame
    private void Update()
    {
        if (jafoi == false)
        {
            progress.gameObject.SetActive(true);
            progress.color = cont;
            progress.type = Image.Type.Filled;
            progress.fillMethod = Image.FillMethod.Horizontal;
            progress.fillOrigin = (int)Image.OriginHorizontal.Right;
            
        }
        
        if (tempo > 0)
        {
            jafoi = true;
            tempo -= Time.deltaTime;
            pro = (int)(tempo * 100.0f);
        }
        
       
        if(comeca ==false)
        {
       
         comeca = true;
         Invoke("Morte", 30);
        }
        
progress.fillAmount = (pro / 3000.0f);


    }

    void FixedUpdate()
    {
        
       
        if ( Vector3.Distance(transform.position, player.position) >30)
        {
            animarato.SetBool("andando", true);
            jasetou = true;
            ratonav.enabled = true;
            ratonav.SetDestination(player.position);
            Invoke("Segue", 3);
            
           
        }
        if (Vector3.Distance(transform.position, player.position) < 30 && jasetou == false && inimigoaqui == false)
        {
            animarato.SetBool("andando", true);
            ratonav.enabled = true;
            ratonav.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) < 3)
            {
                animarato.SetBool("andando", false);
                ratonav.enabled = false;
            }
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.CompareTag("inimigo") && jasetou== false && Vector3.Distance(transform.position, player.position) < 30)
        {
            animarato.SetBool("andando", true);
            inimigoaqui = true;
            jasetou = true;
            ratonav.enabled = true;
            ratonav.SetDestination(other.transform.position);
            any.name = other.name;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if( other.name == any.name)
        {
            any.transform.position = other.transform.position;
            ratonav.SetDestination(any.transform.position);
            Segueinimigo();
        }
        
    }
    
    
    void Segue()
    {
        jasetou = false;
    }
    public void Segueinimigo()
    {
        if (jasetou == true)
        {
        ratonav.SetDestination(any.transform.position);
        }
    }
    void Morte()
    {
        progress.gameObject.SetActive(false);
        tempo = 30;
       
        ajuda.Atacadoajudante = false;
        comeca = false;
        arearato.active = false;
        gameObject.active = false;
        ativ.enabled = true;
        ativ.javai = false;
    }
}


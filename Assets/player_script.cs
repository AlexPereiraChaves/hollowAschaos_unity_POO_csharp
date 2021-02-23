using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{
    Vector3 pos;
    public float   MoveSpeed = 10f;
    public bool setaoescudo = false;
    Animator espa ;
    public hammer trocar;
    public Animator pivo, anima;
    public danobossnoplayer danoboss;
    public boss_areadano levarea;
    public playerDash_script ativoDash;
    public ParticleSystem max, maxpequeno,blood, empursy;
    bool tocaChao = false,damage, martelada;
    float tamTela = 100f ;
    int limtChao;
    Rigidbody rigidy;
    public GameObject Hammer, Magico, Espada, pivoHammer;
    public int vidaInicial;
    public int vidaAtual=200, escudo_vida;
    public Slider barravida, barraGolpe;
    public GameObject danodano;
    public shild_live vida_escudo;
    public Text morreu;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Image DamageImage, motao;
    public float flashSpeed = 5f, timer, tomo;
    public bool espadabool;
    public MeshRenderer Escudo;
    public BoxCollider Escudo_box;
    public bool espadaatacando, empurre,winzada;
    public Image conf1, conf2, conf3, wins;
    Transform bla;
    public Transform empurrada;
    float xs, ys;
    public camera came;
    void Start()
    {
        wins.enabled = false;
        motao.enabled = false;
        pivoHammer.SetActive(false);
        morreu.enabled = false;
        barraGolpe.enabled = false;
        rigidy = GetComponent<Rigidbody>();
        limtChao = LayerMask.GetMask("chao");
        Hammer.SetActive(false);
        barravida.value = vidaAtual;
        Escudo_box.enabled = false;
        conf1.enabled = false; conf2.enabled = true; conf3.enabled = false;
        winzada = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (winzada == true)
        {
            Venceu();
        }
        if (empurre == true)
        {
            empurre = false;
            transform.position = empurrada.position;
            empursy.transform.position = transform.position;
            empursy.Play();
          
        }
        if(motao.enabled == true)
        {


            came.enabled = false;
            
            xs += 0.3f;ys += 0.3f;
            
            motao.transform.localScale= new Vector3(xs,ys,1);
        }
        martelada = pivo.GetBool("atacando");
        if (Input.GetKey(KeyCode.Mouse1) && Hammer.active == true)
        {
            
            barraGolpe.enabled = true;
            if(Input.GetKey(KeyCode.Mouse1) && Hammer.active == true && barraGolpe.value <=5 )
            {
                pivo.GetComponent<Animator>().SetBool("concentrado", true);
                barraGolpe.value += 0.04f ;
               
            }
            if (barraGolpe.value <= 4.4 && barraGolpe.value >= 3 &&!maxpequeno.isPlaying)
            {
                maxpequeno.Play();
            }
            if(barraGolpe.value <= 5&& barraGolpe.value >=4.5 && !max.isPlaying)
            {
                maxpequeno.Stop();
                max.Play();
            }
           
        }


            if (!Input.GetKey(KeyCode.Mouse1) && Hammer.active == true || false)
        {
            barraGolpe.enabled = false;
            maxpequeno.Stop();
            pivo.GetComponent<Animator>().SetBool("concentrado", false);
            max.Stop();
        }


        escudo_vida = vida_escudo.GetComponent<shild_live>().escudovida;
        timer +=Time.deltaTime;
        tomo += Time.deltaTime;
       
       
      
        float movVertical = Input.GetAxis("Vertical");
        float movHorizontal= Input.GetAxis("Horizontal");
        espa = Espada.GetComponent<Animator>();
      
     if ( anima.GetBool("tocachao") == false &&movHorizontal != 0|| movVertical !=0 && anima.GetBool("tocachao") == false)
        {
            anima.SetBool("caminhando", true);
        }
        else
        {
            anima.SetBool("caminhando", false);
        }
     if ( tocaChao ==false && Input.GetKeyDown(KeyCode.Space)&& tomo >2)
        {
           // tomo = 0;
          
           // rigidy.AddForce(transform.forward * -23, ForceMode.VelocityChange);
           // anima.SetBool("pulando", true);
        }
        else
        {
            anima.SetBool("pulando", false);
        }
       

         
        if (damage==true)
        {
            DamageImage.color = flashColour;
        }
        else { DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
          
        }
        damage = false;
        if (espadabool == true && tocaChao ==false)
        {
            if (Input.GetKey(KeyCode.Mouse0) && timer > 0.5f)
            {
                timer = 0;
                espa.SetBool("atacando", true);
                espadaatacando = true;
            }
            else
            {
                espa.SetBool("atacando", false);
            }
        } 
    }
    public void FixedUpdate()
    {
        rotacao();
          if (Input.GetKey(KeyCode.Alpha1))
        {
            conf1.enabled = true; conf2.enabled = false; conf3.enabled = false;
            setaoescudo = false;
            ativoDash.enabled = false;
            pivoHammer.SetActive (true);
            Hammer.SetActive(true);
            Magico.SetActive(false);
            // Espada.SetActive(false);
            Escudo.enabled = false;
            Escudo_box.enabled = false;
            espadabool = false;
           



        }
        if (Input.GetKey(KeyCode.Alpha2)&& martelada == false && barraGolpe.value == 0 && trocar.naotroca==false)
        {
            conf1.enabled = false; conf2.enabled = true; conf3.enabled = false;
            setaoescudo = false;
            pivoHammer.SetActive(false);
            ativoDash.enabled = true;
            //Espada.SetActive(false);
            Hammer.SetActive(false);
            Magico.SetActive(true);
            Escudo.enabled = false;
            Escudo_box.enabled=false;
            espadabool = false;
           
        }
        if (Input.GetKey(KeyCode.Alpha3) && martelada== false && barraGolpe.value ==0 && trocar.naotroca == false)
        {
            conf1.enabled = false; conf2.enabled = false; conf3.enabled = true;
            setaoescudo = true;
            pivoHammer.SetActive(false);
            ativoDash.enabled = true;
            Espada.SetActive(true);
            Hammer.SetActive(false);
            Magico.SetActive(false);
            espadabool = true;
            if (escudo_vida >= 0)
            {
                Escudo.enabled = true;
                Escudo_box.enabled = true;
            }
            setaoescudo = true;
        }
        
        
    }


    void rotacao()
    {
        if (martelada == true)
        {
            anima.SetBool("martelada", true);
        }
        if (martelada == false && motao.enabled==false)
        {
            anima.SetBool("martelada", false);
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit miraChao;
            if (Physics.Raycast(camRay, out miraChao, tamTela, limtChao))
            {
                if (Hammer.active != true )
                {
                    Vector3 playerToMouse = miraChao.point - transform.position;
                    playerToMouse.y = 0f;
                    Quaternion novaRotacao = Quaternion.LookRotation(playerToMouse);
                    rigidy.MoveRotation(novaRotacao);
                    pos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    pos = pos.normalized *3.5f* Time.deltaTime;
                    rigidy.MovePosition(transform.position + pos);
                }
                

                if (Hammer.active == true && barraGolpe.value == 0 && !Input.GetKey(KeyCode.LeftShift))
                {
                    Vector3 playerToMouse = miraChao.point - transform.position;
                    playerToMouse.y = 0f;
                    Quaternion novaRotacao = Quaternion.LookRotation(playerToMouse);
                    rigidy.MoveRotation(novaRotacao);
                    pos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    pos = pos.normalized * 2f * Time.deltaTime;
                    rigidy.MovePosition(transform.position + pos);
                }
                if (Hammer.active == true && barraGolpe.value == 0 && Input.GetKey(KeyCode.LeftShift))
                {
                    Vector3 playerToMouse = miraChao.point - transform.position;
                    playerToMouse.y = 0f;
                    Quaternion novaRotacao = Quaternion.LookRotation(playerToMouse);
                    rigidy.MoveRotation(novaRotacao);
                    pos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    pos = pos.normalized * 3f * Time.deltaTime;
                    rigidy.MovePosition(transform.position + pos);
                }

                if (Hammer.active == true && barraGolpe.value != 0 && !Input.GetKey(KeyCode.LeftShift))
                {
                    Vector3 playerToMouse = miraChao.point - transform.position;
                    playerToMouse.y = 0f;
                    Quaternion novaRotacao = Quaternion.LookRotation(playerToMouse);
                    rigidy.MoveRotation(novaRotacao);
                    pos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    pos = pos.normalized * 2f * Time.deltaTime;
                    rigidy.MovePosition(transform.position + pos);
                }
                if (Hammer.active == true && barraGolpe.value != 0 && Input.GetKey(KeyCode.LeftShift))
                {
                    Vector3 playerToMouse = miraChao.point - transform.position;
                    playerToMouse.y = 0f;
                    Quaternion novaRotacao = Quaternion.LookRotation(playerToMouse);
                    rigidy.MoveRotation(novaRotacao);
                    pos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    pos = pos.normalized * 2f * Time.deltaTime;
                    rigidy.MovePosition(transform.position + pos);
                }
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "chao")
        {
            tocaChao = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            tocaChao = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag( "pilar"))
        {
            levarea.podelevardano = false;
        }
    }
    public void LevaDano(int amount)
    {
        damage = true;
        vidaAtual -= amount;
        barravida.value = vidaAtual;
        if( danoboss.bateu== true)
        {
            empurre= true;
            blood.transform.position = transform.position;
            blood.Play();
            rigidy.AddForce(transform.forward * -23, ForceMode.VelocityChange);
           
        }
     
        if(vidaAtual <= 0 )
        {
            
            motao.enabled = true;
          //  morreu.enabled = true;
          Invoke("Morreu", 2);
        }
    }
    
   
   void Morreu()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void Venceu()
    {
        wins.enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
           
            SceneManager.LoadScene("Menu");
        }
    }
 }

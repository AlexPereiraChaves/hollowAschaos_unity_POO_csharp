using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class move_magico : MonoBehaviour
{
    RaycastHit mira;
    Rigidbody rb;
    Vector3 pos;
    float tamTela = 100f;
    public Transform player;
    float MoveSpeedvolta = 20f;
    float timer;
    public float MoveSpeed =40f;
    public Image relogio;
    public ParticleSystem pas;
    Vector3 offset;
    public GameObject spear;
    void Start()
    {
        
        offset = transform.position - player.position;
        rb = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), 1000* Time.deltaTime);
        
    }
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse0)&& timer>=1 && spear.active == true)
        {
            pas.Play();
        }
        if (Input.GetKey(KeyCode.Mouse0)&& timer <1)
        {
            timer+=Time.deltaTime;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mira, tamTela))
            {
                Vector3 playerTomouse = mira.point;
                playerTomouse.y = 1;
                // transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

                //pos.x = playerTomouse.x - MoveSpeed;
                //pos.z = playerTomouse.z - MoveSpeed;
                transform.position = Vector3.Lerp(transform.position, playerTomouse, MoveSpeed * Time.deltaTime);

                //pos.y = 1f;
                //transform.position = pos;
            }




        }
        else
        {
            Vector3 playerv = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, playerv , MoveSpeedvolta * Time.deltaTime);
            pos = transform.position;
            if (timer >= 1)
            {
                Invoke("Jar", 3f);
                relogio.gameObject.SetActive(true);
            }

        }
        if( pos.y<= 0)
        {
            pos.y = 1;
            transform.position = pos;
        }
    }
   private void Jar()
    {
        relogio.gameObject.SetActive(false);
        timer = 0;
    }
}

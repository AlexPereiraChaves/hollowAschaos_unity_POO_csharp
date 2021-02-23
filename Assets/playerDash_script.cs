using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDash_script : MonoBehaviour
{
    public float speed = 10f;
    float timer;
    public Vector3 lastMoveDir;
    public ParticleSystem dash_anima;
    public AudioSource sourceplayer;
    
   
    private void Awake()
    {
        dash_anima.playbackSpeed = 8;
        


    }

    private void Update()
    {
        Anotmove();
        Dash();
    }

    void Anotmove()
    {
        float movVertical = Input.GetAxis("Vertical");
        float movHorizontal = Input.GetAxis("Horizontal");
        timer += Time.deltaTime;
        
        Vector3 moveDir = new Vector3(movHorizontal, 0 ,movVertical).normalized;
      
       
        if(Trymove(moveDir, speed*Time.deltaTime))
        {
           
            
           
        }
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime);
        if (raycast.collider == null)
        {
            lastMoveDir = moveDir;
        }
    }
    bool CanMove(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance).collider == null;
    }
    bool Trymove(Vector3 baseMovedir, float distance)
    {
        Vector3 moveDir = baseMovedir;
        bool canmove = CanMove(moveDir, distance);
        if (!canmove)
        {
            moveDir = new Vector3(baseMovedir.x, 0f, 0f).normalized;
            canmove = CanMove(moveDir, distance);
            if (!canmove)
            {
                moveDir = new Vector3(0f, 0f, baseMovedir.z).normalized;
                canmove = CanMove(moveDir, distance);
            }
        }
        if (canmove)
        {
            lastMoveDir = moveDir;
            transform.position += moveDir *distance;
            return true;
        }
        else
        {
            return false;
        }
    }
    void Dash()
    {
        if (Input.GetKey(KeyCode.Mouse1)&& timer>1f)
        {
            Vector3 animaPosi = transform.position;
            dash_anima.transform.position = animaPosi;
            float DashDistance = 1f;

            sourceplayer.Play();
            timer = 0;
            dash_anima.Play();
            Trymove(lastMoveDir, DashDistance);
            transform.position += lastMoveDir * DashDistance;
            
        }
    }
       
    
}
     

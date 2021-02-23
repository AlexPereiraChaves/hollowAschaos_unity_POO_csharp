using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class produztiro : MonoBehaviour
{
    
    public Transform positionShoot;
    public GameObject bullet;
    public float speed;
    public Transform player;
    float timer;

      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        
            if (Vector3.Distance(transform.position, player.position) < 15 && timer >= 1)
            {
                timer = 0;
                InstantiateBullet();
            }
        
    }
    void InstantiateBullet()
    {
        if(bullet != null)
        {
            GameObject tempBullet = Instantiate(bullet) as GameObject;
            tempBullet.transform.position = transform.position;
            tempBullet.GetComponent<Rigidbody>().velocity = transform.parent.forward * speed;
            Destroy(tempBullet, 6);
        }
    }
}

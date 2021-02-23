using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class logoi : MonoBehaviour
{
    public Image ima;

    float timer, xs,ys;
    // Start is called before the first frame update
    void Start()
    {
        xs = 11;
        ys = 4; 
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        xs += 0.01f; ys += 0.01f;

       ima.transform.localScale = new Vector3(xs, ys, 5);
        if (timer>= 4)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativarato : MonoBehaviour
{
    public Text textratao;
    public Color azul;
    public GameObject rato;
    public GameObject arearato;
    public Transform player;
    public Image blog, progress;
    float tempo= 0;
    public ativarato ativ;
    public bool javai =false;
    public ratoscript ja;
    int pro;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        textratao.color = azul;
        progress.gameObject.SetActive(true);
        progress.color = azul;
        if (javai == false)
        {
            progress.type = Image.Type.Filled;
            progress.fillMethod = Image.FillMethod.Horizontal;
            progress.fillOrigin = (int)Image.OriginHorizontal.Left;
           
        } 

        blog.enabled = true;
        if (tempo <45 )
        {
            javai = true;
            tempo += Time.deltaTime;
            
            pro= (int)(tempo* 100.0f);
        }
        if (tempo> 45)
        {
            textratao.gameObject.SetActive(true);
            textratao.text = ("press E to invoke");
        }
       progress.fillAmount = (pro / 5009.0f);
    }
    private void FixedUpdate()
    {
        
       
        if (Input.GetKey(KeyCode.E) && tempo >45)
        {
            Morte();
        }
    }
    void Morte()
    {
        progress.gameObject.SetActive(false);
        blog.enabled = false;
        tempo = 0;
        textratao.gameObject.SetActive(false); 
        rato.transform.position = player.position;
        arearato.gameObject.SetActive(true);
        rato.gameObject.SetActive(true);
        ja.jafoi = false;
        ativ.enabled = false;
    }
}

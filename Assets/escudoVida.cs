using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escudoVida : MonoBehaviour
{
    public GameObject shild;
    int addescudo = 50;
    public int vidaDoescudo;
    bool d = false;
    public Slider barraescudo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);
       
    }
    private void FixedUpdate()
    {
     vidaDoescudo = shild.GetComponent<shild_live>().escudovida;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && d == false)
        {
            GetComponent<MeshRenderer>().enabled = false;
            AddVida();
            d = true;
            Invoke("Morte", 0.5f);
        }
    }
    public void AddVida()
    {
        if (vidaDoescudo <= 100)
        {
            vidaDoescudo += addescudo;
            //player.GetComponent<player_script>().escudovida = vidaDoescudo;
            shild.GetComponent<shild_live>().escudovida = vidaDoescudo;
            barraescudo.value = vidaDoescudo;
            shild.GetComponent<shild_live>().oncetrig = false;
            shild.GetComponent<shild_live>().Escudoimage.color = Color.clear;
        }
    }
    void Morte()
    {
        gameObject.SetActive(false);
    }
}

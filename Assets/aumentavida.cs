using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aumentavida : MonoBehaviour
{
    public player_script player;
    int addescudo = 50;
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
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && d == false)
        {
            
            AddVida();
            d = true;
            Invoke("Morte", 0.1f);
        }
    }
    public void AddVida()
    {
      
      
            player.vidaAtual += addescudo;
            barraescudo.value = player.vidaAtual;
      
    }
    void Morte()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shild_live : MonoBehaviour
{
    public int escudovida = 10;
    public bool damage;
    public bool  oncetrig;
    public Slider barraescudo;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f) , critico = new Color(1f, 0f, 0f, 0.1f), preto = new Color(1f,0f,0f,0.1f);
    public Image DamageImage, Escudoimage;
    public float flashSpeed = 5f;
    public BoxCollider Escudo_box;
    public MeshRenderer Escudo_mesh;
    public player_script esculada;
    // Start is called before the first frame update
    void Start()
    {
        
        barraescudo.value = escudovida;
        Escudoimage.color = Color.clear;

    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (damage == true && escudovida>0)
        {
            DamageImage.color = flashColour;
            if ((escudovida <= 30 && escudovida > 0 && oncetrig == false))
            {
                Critiimage();
            }
        }
        else
        {
          DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
         
        }
        damage = false;
        if (escudovida >= 0 && esculada.setaoescudo == true)
        {
            Escudo_box.enabled = true;
            Escudo_mesh.enabled = true;
        }
    }
    
    public void LevaDano(int amount)
    {
        damage = true;
        
       
         
         
              escudovida -= amount;
              barraescudo.value = escudovida;
         
        if (escudovida <= 0)
        {
            oncetrig = true;
            //play animation;
            Escudo_box.enabled = false;
            Escudo_mesh.enabled = false;
            Escudoimage.color = preto;
        }
      
    }
    void Critiimage()
    {
        if (oncetrig == false && escudovida<31)
        {
            
            Escudoimage.color = critico;
            Invoke("Setouimag", 0.5f);
        }
    }
    void Setouimag()
    {
        if (oncetrig == false)
        {
           
            Escudoimage.color = Color.clear;// Color.Lerp(Escudoimage.color, Color.clear, flashSpeed * Time.deltaTime);
            Invoke("Critiimage", 0.5f);
        }
    }
}

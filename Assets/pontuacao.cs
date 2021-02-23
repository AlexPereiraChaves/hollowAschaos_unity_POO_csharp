using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontuacao : MonoBehaviour
{
    public int pontos = 0;
    public Text pontostela;
    public GameObject boss;
    bool jasetou = false;
    
    void Start()
    {
        pontostela.text = ("Pontuação: " + pontos);
    }

    
    void FixedUpdate()
    {
        pontostela.text = ("Pontuação: " + pontos);
        if( pontos >=580 && jasetou==false)
        {
           
            boss.SetActive(true);
            jasetou = true;
        }
    }
}

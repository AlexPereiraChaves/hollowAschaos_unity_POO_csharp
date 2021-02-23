using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LOAD : MonoBehaviour
{
    public bool jogar = false, oncetrigger=false;
    public string cenar;
    public float TempoFixoseg = 5; float timer;
    public enum TipoCarreg { Carregamento, Tempofixo};
    public TipoCarreg Tipocarregamento;
    public Image barra;
    public Text textprogresso;
    private int progresso = 0;
    private string textoOriginal;
    
    void Start()
    {
        barra.gameObject.SetActive(false);
        textprogresso.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (oncetrigger == false && jogar==true)
        {
            barra.gameObject.SetActive(true);
            textprogresso.gameObject.SetActive(true);
            oncetrigger = true;
            switch (Tipocarregamento)
            {
                case TipoCarreg.Carregamento:
                    StartCoroutine(CenaDeCarregamento(cenar));
                    break;
                case TipoCarreg.Tempofixo:
                    StartCoroutine(TempoFixo(cenar));
                    break;
            }
            if (textprogresso != null)
            {
                textoOriginal = textprogresso.text;
            }
            if (barra != null)
            {
                barra.type = Image.Type.Filled;
                barra.fillMethod = Image.FillMethod.Horizontal;
                barra.fillOrigin = (int)Image.OriginHorizontal.Left;
            }

            
            IEnumerator CenaDeCarregamento(string cena)
            {
                AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
                while (!carregamento.isDone)
                {
                    progresso = (int)(carregamento.progress * 100.0f);
                    yield return null;
                   
                }
            }
            IEnumerator TempoFixo(string cena)
            {
                yield return new WaitForSeconds(TempoFixoseg);
                SceneManager.LoadScene(cena);
                
            }
            
        }
        if (jogar == true)
        {
            
               timer +=0.05f;
        }
        if (jogar == true)
        {
            switch (Tipocarregamento)
            {


                
                case TipoCarreg.Tempofixo:
                    progresso = (int)(Mathf.Clamp((timer / TempoFixoseg), 0.0f, 1.0f) * 100.0f);
                    break;
            }
            if (textprogresso != null)
            {
                textprogresso.text = textoOriginal + " " + progresso + "%";
            }
            if (barra != null)
            {
                barra.fillAmount = (progresso / 100.0f);
            }
        }
    }
}

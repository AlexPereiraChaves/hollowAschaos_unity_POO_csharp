using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System;
using  TMPro;

[Serializable]
public class Carregar
{
    
    public Image barraDeCarregamento;
    public Text TextoProgresso;
    [HideInInspector]
    public int progresso = 0;
    [HideInInspector]
    public string textoOriginal;
}

public class MENU : MonoBehaviour
{
    public LOAD load;
    public Button BotaoJogar, BotaoOpcoes, BotaoSair, Botaotruejogar, Botaoposexplain;
    [Space(20)]
    public Slider BarraVolume;
    public Toggle CaixaModoJanela;
    public TextMeshProUGUI armas, movimentarcao, saveexplain, ratoexplain, cavshield;
    public Image spearIm, espadaIm, rarIm, ratoIm, saveIm, cavIm, dashIm, puloIm;
    public Dropdown Resolucoes, Qualidades;
    public Button BotaoVoltar, BotaoSalvarPref,Botaovoltaexplain, Botaoavancar, BotaoVoltarPos;
    [Space(20)]
    public Text textoVol, resolin;
    public string nomeCenaJogo = "CENA1";
    [Space(20)]
    public Carregar Loading;
    private string nomeDaCena;
    private float VOLUME;
    private int qualidadeGrafica, modoJanelaAtivo, resolucaoSalveIndex;
    private bool telaCheiaAtivada, javai;
    bool explainposfalse;
    private Resolution[] resolucoesSuportadas;
    
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        resolucoesSuportadas = Screen.resolutions;
    }

    void Start()
    {
        resolin.gameObject.SetActive(false);
        armas.gameObject.SetActive(false);
        movimentarcao.gameObject.SetActive(false);
        saveexplain.gameObject.SetActive(false);
        ratoexplain.gameObject.SetActive(false);
        cavshield.gameObject.SetActive(false);
        rarIm.gameObject.SetActive(false);
        Botaoavancar.gameObject.SetActive(false);
        BotaoVoltarPos.gameObject.SetActive(false);
        spearIm.gameObject.SetActive(false);
        espadaIm.gameObject.SetActive(false);
        ratoIm.gameObject.SetActive(false);
        saveIm.gameObject.SetActive(false);
        cavIm.gameObject.SetActive(false);
        dashIm.gameObject.SetActive(false);
        puloIm.gameObject.SetActive(false);

        Botaovoltaexplain.gameObject.SetActive(false);
        Botaoposexplain.gameObject.SetActive(false);
        Loading.barraDeCarregamento.enabled = false;
        Loading.TextoProgresso.enabled = false;
        if (Loading.TextoProgresso != null)
        {
            Loading.textoOriginal = Loading.TextoProgresso.text;
        }
        if (Loading.barraDeCarregamento != null)
        {
            Loading.barraDeCarregamento.type = Image.Type.Filled;
            Loading.barraDeCarregamento.fillMethod = Image.FillMethod.Horizontal;
            Loading.barraDeCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
        //
        Opcoes(false);
        ChecarResolucoes();
        AjustarQualidades();
        //
        if (PlayerPrefs.HasKey("RESOLUCAO"))
        {
            int numResoluc = PlayerPrefs.GetInt("RESOLUCAO");
            if (resolucoesSuportadas.Length <= numResoluc)
            {
                PlayerPrefs.DeleteKey("RESOLUCAO");
            }
        }
        //
        nomeDaCena = SceneManager.GetActiveScene().name;
        Cursor.visible = true;
        Time.timeScale = 1;
        //
        BarraVolume.minValue = 0;
        BarraVolume.maxValue = 1;

        //=============== SAVES===========//
        if (PlayerPrefs.HasKey("VOLUME"))
        {
            VOLUME = PlayerPrefs.GetFloat("VOLUME");
            BarraVolume.value = VOLUME;
        }
        else
        {
            PlayerPrefs.SetFloat("VOLUME", 1);
            BarraVolume.value = 1;
        }
        //=============MODO JANELA===========//
        if (PlayerPrefs.HasKey("modoJanela"))
        {
            modoJanelaAtivo = PlayerPrefs.GetInt("modoJanela");
            if (modoJanelaAtivo == 1)
            {
                Screen.fullScreen = false;
                CaixaModoJanela.isOn = true;
            }
            else
            {
                Screen.fullScreen = true;
                CaixaModoJanela.isOn = false;
            }
        }
        else
        {
            modoJanelaAtivo = 0;
            PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
            CaixaModoJanela.isOn = false;
            Screen.fullScreen = true;
        }
        //========RESOLUCOES========//
        if (modoJanelaAtivo == 1)
        {
            telaCheiaAtivada = false;
        }
        else
        {
            telaCheiaAtivada = true;
        }
        if (PlayerPrefs.HasKey("RESOLUCAO"))
        {
            resolucaoSalveIndex = PlayerPrefs.GetInt("RESOLUCAO");
            Screen.SetResolution(resolucoesSuportadas[resolucaoSalveIndex].width, resolucoesSuportadas[resolucaoSalveIndex].height, telaCheiaAtivada);
            Resolucoes.value = resolucaoSalveIndex;
        }
        else
        {
            resolucaoSalveIndex = (resolucoesSuportadas.Length - 1);
            Screen.SetResolution(resolucoesSuportadas[resolucaoSalveIndex].width, resolucoesSuportadas[resolucaoSalveIndex].height, telaCheiaAtivada);
            PlayerPrefs.SetInt("RESOLUCAO", resolucaoSalveIndex);
            Resolucoes.value = resolucaoSalveIndex;
        }
        //=========QUALIDADES=========//
        if (PlayerPrefs.HasKey("qualidadeGrafica"))
        {
            qualidadeGrafica = PlayerPrefs.GetInt("qualidadeGrafica");
            QualitySettings.SetQualityLevel(qualidadeGrafica);
            Qualidades.value = qualidadeGrafica;
        }
        else
        {
            QualitySettings.SetQualityLevel((QualitySettings.names.Length - 1));
            qualidadeGrafica = (QualitySettings.names.Length - 1);
            PlayerPrefs.SetInt("qualidadeGrafica", qualidadeGrafica);
            Qualidades.value = qualidadeGrafica;
        }

        // =========SETAR BOTOES==========//
        BotaoJogar.onClick = new Button.ButtonClickedEvent();
        Botaotruejogar.onClick = new Button.ButtonClickedEvent();
        BotaoOpcoes.onClick = new Button.ButtonClickedEvent();
        BotaoSair.onClick = new Button.ButtonClickedEvent();
        BotaoVoltar.onClick = new Button.ButtonClickedEvent();
        Botaovoltaexplain.onClick = new Button.ButtonClickedEvent();
        Botaoposexplain.onClick = new Button.ButtonClickedEvent();
        BotaoSalvarPref.onClick = new Button.ButtonClickedEvent();
        Botaoavancar.onClick = new Button.ButtonClickedEvent();
        BotaoVoltarPos.onClick = new Button.ButtonClickedEvent();
        BotaoJogar.onClick.AddListener(() => Jogar());
        BotaoVoltarPos.onClick.AddListener(() => Explainop(true));
        Botaotruejogar.onClick.AddListener(() => Explainop(true));
        Botaoavancar.onClick.AddListener(() => Expplaindois(true));
        
        BotaoOpcoes.onClick.AddListener(() => Opcoes(true));
        Botaoposexplain.onClick.AddListener(() => LoadStart());
        Botaovoltaexplain.onClick.AddListener(() => Explainop(false));
        BotaoSair.onClick.AddListener(() => Sair());
        BotaoVoltar.onClick.AddListener(() => Opcoes(false));
        BotaoSalvarPref.onClick.AddListener(() => SalvarPreferencias());
    }
    //=========VOIDS DE CHECAGEM==========//
    private void ChecarResolucoes()
    {
        Resolution[] resolucoesSuportadas = Screen.resolutions;
        Resolucoes.options.Clear();
        for (int y = 0; y < resolucoesSuportadas.Length; y++)
        {
            Resolucoes.options.Add(new Dropdown.OptionData() { text = resolucoesSuportadas[y].width + "x" + resolucoesSuportadas[y].height });
        }
        Resolucoes.captionText.text = "Resolucao";
    }
    private void AjustarQualidades()
    {
        string[] nomes = QualitySettings.names;
        Qualidades.options.Clear();
        for (int y = 0; y < nomes.Length; y++)
        {
            Qualidades.options.Add(new Dropdown.OptionData() { text = nomes[y] });
        }
        Qualidades.captionText.text = "Qualidade";
    }
    private void Opcoes(bool ativarOP)
    {
        BotaoJogar.gameObject.SetActive(!ativarOP);
        Botaotruejogar.gameObject.SetActive(!ativarOP);
        BotaoOpcoes.gameObject.SetActive(!ativarOP);
        BotaoSair.gameObject.SetActive(!ativarOP);

        /* saveexplain.gameObject.SetActive(!ativarOP);
         ratoexplain.gameObject.SetActive(!ativarOP);
         cavshield.gameObject.SetActive(!ativarOP);
         cavIm.gameObject.SetActive(!ativarOP);
         ratoIm.gameObject.SetActive(!ativarOP);
         saveIm.gameObject.SetActive(!ativarOP);
         BotaoVoltarPos.gameObject.SetActive(!ativarOP);
         Botaoavancar.gameObject.SetActive(!ativarOP);*/
        //
        resolin.gameObject.SetActive(ativarOP);
        textoVol.gameObject.SetActive(ativarOP);
        BarraVolume.gameObject.SetActive(ativarOP);
        CaixaModoJanela.gameObject.SetActive(ativarOP);
        Resolucoes.gameObject.SetActive(ativarOP);
        Qualidades.gameObject.SetActive(ativarOP);
        BotaoVoltar.gameObject.SetActive(ativarOP);
        BotaoSalvarPref.gameObject.SetActive(ativarOP);
        
    }
    private void Explainop(bool ativ)
    {
        Botaotruejogar.gameObject.SetActive(!ativ);
        BotaoJogar.gameObject.SetActive(!ativ);
        BotaoOpcoes.gameObject.SetActive(!ativ);
        BotaoSair.gameObject.SetActive(!ativ);
       
      
        if(explainposfalse == false)
        {
            saveexplain.gameObject.SetActive(false);
            ratoexplain.gameObject.SetActive(false);
            cavshield.gameObject.SetActive(false);
            cavIm.gameObject.SetActive(false);
            ratoIm.gameObject.SetActive(false);
            saveIm.gameObject.SetActive(false);
            BotaoVoltarPos.gameObject.SetActive(false);
        }

        Botaoavancar.gameObject.SetActive(ativ);
        armas.gameObject.SetActive(ativ);
        movimentarcao.gameObject.SetActive(ativ);
        spearIm.gameObject.SetActive(ativ);
        espadaIm.gameObject.SetActive(ativ);
        rarIm.gameObject.SetActive(ativ);
        dashIm.gameObject.SetActive(ativ);
        puloIm.gameObject.SetActive(ativ);
        Botaoposexplain.gameObject.SetActive(ativ);
        Botaovoltaexplain.gameObject.SetActive(ativ);
    }
    private void Expplaindois(bool atividad)
    {
        explainposfalse =false;
        Botaotruejogar.gameObject.SetActive(!atividad);
        BotaoJogar.gameObject.SetActive(!atividad);
        BotaoOpcoes.gameObject.SetActive(!atividad);
        BotaoSair.gameObject.SetActive(!atividad);
        saveexplain.gameObject.SetActive(atividad);
        ratoexplain.gameObject.SetActive(atividad);
        cavshield.gameObject.SetActive(atividad);
        cavIm.gameObject.SetActive(atividad);
        ratoIm.gameObject.SetActive(atividad);
        saveIm.gameObject.SetActive(atividad);
        BotaoVoltarPos.gameObject.SetActive(atividad);
        Botaoposexplain.gameObject.SetActive(atividad);
        Botaovoltaexplain.gameObject.SetActive(atividad);


        Botaoavancar.gameObject.SetActive(!atividad);
        armas.gameObject.SetActive(!atividad);
        movimentarcao.gameObject.SetActive(!atividad);
        spearIm.gameObject.SetActive(!atividad);
        espadaIm.gameObject.SetActive(!atividad);
        rarIm.gameObject.SetActive(!atividad);
        dashIm.gameObject.SetActive(!atividad);
        puloIm.gameObject.SetActive(!atividad);
        
    }
    //=========VOIDS DE SALVAMENTO==========//
    private void SalvarPreferencias()
    {
        if (CaixaModoJanela.isOn == true)
        {
            modoJanelaAtivo = 1;
            telaCheiaAtivada = false;
        }
        else
        {
            modoJanelaAtivo = 0;
            telaCheiaAtivada = true;
        }
        PlayerPrefs.SetFloat("VOLUME", BarraVolume.value);
        PlayerPrefs.SetInt("qualidadeGrafica", Qualidades.value);
        PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
        PlayerPrefs.SetInt("RESOLUCAO", Resolucoes.value);
        resolucaoSalveIndex = Resolucoes.value;
        AplicarPreferencias();
    }
    private void AplicarPreferencias()
    {
        VOLUME = PlayerPrefs.GetFloat("VOLUME");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualidadeGrafica"));
        Screen.SetResolution(resolucoesSuportadas[resolucaoSalveIndex].width, resolucoesSuportadas[resolucaoSalveIndex].height, telaCheiaAtivada);
    }
   /* IEnumerator CenaDeCarregamento(string cena)
    {
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
        while (!carregamento.isDone)
        {
            Loading.progresso = (int)(carregamento.progress * 100.0f);
            yield return null;
        }
    }*/
    //===========VOIDS NORMAIS=========//
    void Update()
    {
      /*  if (Loading.TextoProgresso != null)
        {
            Loading.TextoProgresso.text = Loading.textoOriginal + " " + Loading.progresso + "%";
        }
        if (Loading.barraDeCarregamento != null)
        {
            Loading.barraDeCarregamento.fillAmount = (Loading.progresso / 100.0f);
        }*/
        if (SceneManager.GetActiveScene().name != nomeDaCena)
        {
            AudioListener.volume = VOLUME;
            Destroy(gameObject);
        }
    }
    private void Jogar()
    {
        Opcoes(false);
        BotaoJogar.gameObject.SetActive(false);
        BotaoOpcoes.gameObject.SetActive(false);
        Botaotruejogar.gameObject.SetActive(false);
        BotaoSair.gameObject.SetActive(false);
        load.jogar = true;
        
        //Loading.barraDeCarregamento.enabled = true;
      //  Loading.TextoProgresso.enabled = true;
        //StartCoroutine(CenaDeCarregamento(nomeCenaJogo));
        
    }
    private void Sair()
    {
        Application.Quit();
    }
    
    private void LoadStart()
    {
        armas.gameObject.SetActive(false);
        movimentarcao.gameObject.SetActive(false);
        saveexplain.gameObject.SetActive(false);
        ratoexplain.gameObject.SetActive(false);
        cavshield.gameObject.SetActive(false);
        spearIm.gameObject.SetActive(false);
        espadaIm.gameObject.SetActive(false);
        ratoIm.gameObject.SetActive(false);
        saveIm.gameObject.SetActive(false);
        cavIm.gameObject.SetActive(false);
        dashIm.gameObject.SetActive(false);
        puloIm.gameObject.SetActive(false);
        Botaovoltaexplain.gameObject.SetActive(false);
        Botaoposexplain.gameObject.SetActive(false);
        BotaoVoltarPos.gameObject.SetActive(false);
        Botaoavancar.gameObject.SetActive(false);
        rarIm.gameObject.SetActive(false);
        load.jogar = true;
        //Loading.barraDeCarregamento.enabled = true;
        //  Loading.TextoProgresso.enabled = true;
        //  StartCoroutine(CenaDeCarregamento(nomeCenaJogo));
    }
}

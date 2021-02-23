using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerInterface : MonoBehaviour
{
    string Spa1, Spa2, Spa3, Spa4, Spa5, Spa6, Spa7;// ====> ESTAS SAO DOS ALIENS RÁPIDOS
    string Shield1, Shield2, Shield3, Shield4, Shield5, Shield6;
    string Fo1, Fo2, Fo3, Fo4;
    string Cav1, Cav2, Cav3;
    public string carregado;
    public GameObject spa1, spa2, spa3, spa4, spa5, spa6, spa7;
    public GameObject alien1, alien2, alien3, alien4, alien5, alien6, alien7;
    public GameObject shield1, shield2, shield3, shield4, shield5, shield6;
    public GameObject cav1, cav2, cav3;
    public GameObject fo1, fo2, fo3, fo4;
    public savearea area;
    public player_script player;
    public shild_live shield;
    public pontuacao pont;
    string pontos, vidaplayer, vidaescudo;
    private void Awake()
    {
        string[] valoresRetornados = BancoDeDados.carregarDados();
        carregado = "Carregado";
        Spa1 = valoresRetornados[0];
        Spa2 = valoresRetornados[1];
        Spa3 = valoresRetornados[2];
        Spa4 = valoresRetornados[3];
        Spa5 = valoresRetornados[4];
        Spa6 = valoresRetornados[5];
        Spa7 = valoresRetornados[6];
        pontos = valoresRetornados[7];
        Cav1 = valoresRetornados[8];
        Cav2 = valoresRetornados[9];
        Cav3 = valoresRetornados[10];
        vidaplayer = valoresRetornados[11];
        vidaescudo = valoresRetornados[12];
        Shield1 = valoresRetornados[13];
        Shield2 = valoresRetornados[14];
        Shield3 = valoresRetornados[15];
        Shield4 = valoresRetornados[16];
        Shield5 = valoresRetornados[17];
        Shield6 = valoresRetornados[18];
        Fo1 = valoresRetornados[19];
        Fo2 = valoresRetornados[20];
        Fo3 = valoresRetornados[21];
        Fo4 = valoresRetornados[22];
        player.vidaAtual = int.Parse(vidaplayer);
        pont.pontos = int.Parse(pontos);
        shield.escudovida = int.Parse(vidaescudo);
        
        if (pont.pontos > 50)
        {
            spa1.SetActive(false);
        }
        if( pont.pontos>100)
        {
            spa2.SetActive(false);
        }
        if (pont.pontos > 200)
        {
            spa5.SetActive(false);
        }
        if (pont.pontos > 300)
        {
            spa7.SetActive(false);
        }
        if (pont.pontos > 350)
        {
            spa4.SetActive(false);
        }
        if(pont.pontos > 400)
        {
            spa6.SetActive(false);
        }

        if (Spa1 == "false")
        {
            alien1.SetActive(false);
        }
        if (Spa2 == "false")
        {
            alien2.SetActive(false);
        }
        if (Spa3 == "false")
        {
            alien3.SetActive(false);
        }
        if (Spa4 == "false")
        {
            alien4.SetActive(false);
        }
        if (Spa5 == "false")
        {
            alien5.SetActive(false);
        }
        if (Spa6 == "false")
        {
            alien6.SetActive(false);
        }
        if (Spa7 == "false")
        {
            alien7.SetActive(false);
        }
        if( Cav1 == "false")
        {
            cav1.SetActive(false);
        }
        if (Cav2 == "false")
        {
            cav2.SetActive(false);
        }
        if (Cav3 == "false")
        {
            cav3.SetActive(false);
        }
        if( Shield1 == "false")
        {
            shield1.SetActive(false);
        }
        if (Shield2 == "false")
        {
            shield2.SetActive(false);
        }
        if (Shield3 == "false")
        {
            shield3.SetActive(false);
        }
        if (Shield4 == "false")
        {
            shield4.SetActive(false);
        }
        if (Shield5 == "false")
        {
            shield5.SetActive(false);
        }
        if (Shield6 == "false")
        {
            shield6.SetActive(false);
        }
        if( Fo1 == "false")
        {
            fo1.SetActive(false);
        }
        if (Fo2 == "false")
        {
            fo2.SetActive(false);
        }
        if (Fo3 == "false")
        {
            fo3.SetActive(false);
        }
        if (Fo4 == "false")
        {
            fo4.SetActive(false);
        }
    }
    private void OnGUI()
    {
        if (area.Cam == true)
       {
            // myName = GUI.TextField(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 20), myName);
            pontos = pont.pontos.ToString();
            vidaplayer = player.vidaAtual.ToString();
            vidaescudo = shield.escudovida.ToString();
        
            carregado = GUI.TextField(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 20, 100, 20), carregado);
            bool quitTomenu = GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 120, 100, 20), "Quit to menu");
            bool salvarJogo = GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 20), "Salvar jogo");
            bool carregarJogo = GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 70, 100, 20), "Carragar jogo");
            bool Deletar = GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 90, 100, 20), "Deletar saves");
            if (salvarJogo)
            {
                BancoDeDados.salvarDados(alien1, alien2, alien3, alien4, alien5, alien6, alien7, pontos, cav1,cav2,cav3, vidaplayer, vidaescudo, shield1, shield2, shield3, shield4, shield5, shield6 ,fo1, fo2, fo3, fo4);
                carregado = "Salvo";
            }
            if (carregarJogo)
            {
                SceneManager.LoadScene("SampleScene");
               
            }
            if (Deletar)
            {
                BancoDeDados.deletarJogosSalvos();
            }
            if (quitTomenu)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        
    
    }
}

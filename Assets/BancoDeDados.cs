using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BancoDeDados
{
   
    public static void salvarDados( GameObject alien1, GameObject alien2, GameObject alien3, GameObject alien4, GameObject alien5, GameObject alien6, GameObject alien7, string pont, GameObject cav1, GameObject cav2, GameObject cav3, string vidaplayer, string vidaescudo, GameObject shield1, GameObject shield2, GameObject shield3, GameObject shield4, GameObject shield5, GameObject shield6, GameObject fo1, GameObject fo2, GameObject fo3, GameObject fo4)
    {
        
        PlayerPrefs.SetString("pontos", pont);
        PlayerPrefs.SetString("vida", vidaplayer);
        PlayerPrefs.SetString("escudovida", vidaescudo);
        
        if(alien1.active== false)
        {
            PlayerPrefs.SetString("spa1", "false");
        }
        if (alien2.active == false)
        {
            PlayerPrefs.SetString("spa2", "false");
        }
        if (alien3.active == false)
        {
            PlayerPrefs.SetString("spa3", "false");
        }
        if (alien4.active == false)
        {
            PlayerPrefs.SetString("spa4", "false");

        }
        if (alien5.active == false)
        {
            PlayerPrefs.SetString("spa5", "false");
        }
        if (alien6.active == false)
        {
            PlayerPrefs.SetString("spa6", "false");
        }
        if (alien7.active == false)
        {
            PlayerPrefs.SetString("spa7", "false");
        }
        // =====> CAVALEIRO
        if( cav1.active == false)
        {
            PlayerPrefs.SetString("cav1", "false");
        }
        if (cav2.active == false)
        {
            PlayerPrefs.SetString("cav2", "false");
        }
        if (cav3.active == false)
        {
            PlayerPrefs.SetString("cav3", "false");
        }
        // ===========> ESCUDOS 
        if( shield1.active == false)
        {
            PlayerPrefs.SetString("escudo1", "false");
        }
        if (shield2.active == false)
        {
            PlayerPrefs.SetString("escudo2", "false");
        }
        if (shield3.active == false)
        {
            PlayerPrefs.SetString("escudo3", "false");
        }
        if (shield4.active == false)
        {
            PlayerPrefs.SetString("escudo4", "false");
        }
        if (shield5.active == false)
        {
            PlayerPrefs.SetString("escudo5", "false");
        }
        if (shield6.active == false)
        {
            PlayerPrefs.SetString("escudo6", "false");
        }
        if( fo1.active == false)
        {
            PlayerPrefs.SetString("fog1", "false");
        }
        if (fo2.active == false)
        {
            PlayerPrefs.SetString("fog2", "false");
        }
        if (fo3.active == false)
        {
            PlayerPrefs.SetString("fog3", "false");
        }
        if (fo4.active == false)
        {
            PlayerPrefs.SetString("fog4", "false");
        }
        Debug.Log("Dados salvos");
    }
    public static string[] carregarDados()
    {
       
        string valor1 = PlayerPrefs.GetString("spa1", "");
        string valor2 = PlayerPrefs.GetString("spa2", "");
        string valor3 = PlayerPrefs.GetString("spa3", "");
        string valor4 = PlayerPrefs.GetString("spa4", "");
        string valor5 = PlayerPrefs.GetString("spa5", "");
        string valor6 = PlayerPrefs.GetString("spa6", "");
        string valor7 = PlayerPrefs.GetString("spa7", "");
        string valor8 = PlayerPrefs.GetString("pontos", "0");
        string valor9 = PlayerPrefs.GetString("cav1", "");
        string valor10 = PlayerPrefs.GetString("cav2", "");
        string valor11 = PlayerPrefs.GetString("cav3", "");
        string valor12 = PlayerPrefs.GetString("vida", "200");
        string valor13 = PlayerPrefs.GetString("escudovida", "10");
        string valor14 = PlayerPrefs.GetString("escudo1", "");
        string valor15 = PlayerPrefs.GetString("escudo2", "");
        string valor16 = PlayerPrefs.GetString("escudo3", "");
        string valor17 = PlayerPrefs.GetString("escudo4", "");
        string valor18 = PlayerPrefs.GetString("escudo5", "");
        string valor19 = PlayerPrefs.GetString("escudo6", "");
        string valor20 = PlayerPrefs.GetString("fog1", "");
        string valor21 = PlayerPrefs.GetString("fog2", "");
        string valor22 = PlayerPrefs.GetString("fog3", "");
        string valor23 = PlayerPrefs.GetString("fog4", "");

        return new string[] { valor1, valor2, valor3, valor4, valor5,valor6, valor7, valor8 , valor9, valor10, valor11, valor12, valor13, valor14, valor15, valor16,valor17, valor18,valor19, valor20, valor21,valor22,valor23};

    }
    public static void deletarJogosSalvos()
    {
        PlayerPrefs.DeleteAll();
    }
}

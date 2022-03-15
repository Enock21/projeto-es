using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Essa classe vai setar o comportamento do settings do player.
//Até o momento, a única configuração usada é o canPlayerMove, mas, tudo que vá interferir na mecanica do jogador deve ser colcoado para ser configurado aqui
public class Scr_PlayerSettings : MonoBehaviour
{
    public static Scr_PlayerSettings playerSettings;
    private bool canPlayerMove = true;


    //Get e Set do canPlayerMove. Usando o atributo statico, é possivel invocar sem a necessidade de instanciar a clases.
    public static bool CanPlayerMove { get => Scr_PlayerSettings.playerSettings.canPlayerMove; 
        set => Scr_PlayerSettings.playerSettings.canPlayerMove = value; }

    // Start is called before the first frame update
    void Awake()
    {
        Scr_PlayerSettings.playerSettings = this;
    }


    
    
}

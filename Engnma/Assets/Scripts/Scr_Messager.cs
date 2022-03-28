using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Messager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] texts;
    [SerializeField]
    private Scrollbar scroll;

    private static Scr_Messager self;

    public static Scr_Messager Self { get => self; set => self = value; }



    private void Awake()
    {
        CleanScreen();
    }

    void Start()
    {
        Scr_Messager.self = this;
        HelpMessage();

    }

    private void Update()
    {
        
    }

    public void AddMessage(string message)
    {

        texts[0].text += "\n\n" + message;

    }

    public void CleanScreen()
    {
        int length = texts.Length;
        for (int i = 0; i < length; i++)
        {
            texts[i].text = "";
        }
        scroll.value = 0;
    }

    public void Help()
    {
        AddMessage("*** CONSOLE HELP ***"+
            "Nesse mundo vários objetos podem ser manipulados através desse teclado virtual." +
            "\n\n Para digitar um comando válido, é necessário se aproximar do objeto a ser manipulado e" +
            "digitar seu nome, seguido de um ponto e a ação à ser realizada." +
            "\n\n Todas as funções (ações à serem realizadas) precisam abrir e fechar parênteses. Algumas funções " +
            "Sao necessários parâmetros, que são valores que são passado entre os parênteses." +
            "\n\n Comandos do console: \n\nconsole.clear() limpa a tela do teclado, \n\nconsole.help() mostra um texto de ajuda");
    }

    public void HelpMessage()
    {
        AddMessage("Caro jogador, seja bem vindo." +
            "\n Caso haja dúvidas digite console.help() para ver os comandos disponíveis.");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Scr_NPCInteractable : Scr_KeyboardInteractable
{
    private const string KEYBOARD = "KEYBOARD_";
    private const string TURN = "TURN";
    private const string MOVE_X = "MOVEX";
    private const string MOVE_Y = "MOVEY";

    [SerializeField]
    private bool isActiveMove_X, isActiveMove_Y;
    [SerializeField]
    private bool isActiveTurn;

    

    //Faz o npc olhar para o outro lado
    public void Keyboard_Turn()
    {
        if (!isActiveTurn)
            return;
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
    }

    //Move o NPC em X unidades passadas com parametro. 
    public void Keyboard_MoveX(int value)
    {
        if (!isActiveMove_X)
            return;
        Vector3 position = transform.position;
        transform.position = position + new Vector3(value, 0, 0);
    }

    //Move o NPC em Y unidades passadas com parametro. 
    public void Keyboard_MoveY(int value)
    {
        if (!isActiveMove_Y)
            return;
        Vector3 position = transform.position;
        transform.position = position + new Vector3(0, value, 0);
    }

    //Chama a função com o nome passado pelo parametro. É importante que o parametro seja sempre em letra maiuscula,
    //Assim como a constante que armazena o nome da função
    public override void CallFunction(string function)
    {
        print("Função digitada: " + function);
        switch (function)
        {
            case KEYBOARD + TURN:
                Keyboard_Turn();
                break;
            default:
                print("Função não encontrada");
                break;
        }
           
    }
    //Chama a função com o nome passado pelo parametro Todas as funções chamadas por esse metodo possuiem obrigatoriamente parametros.
    //Caso a função não tenha, importante colocar na sobrecarga acima
    // É importante que o parametro seja sempre em letra maiuscula,
    //Assim como a constante que armazena o nome da função
    public override void CallFunction(string function, string parameter)
    {
        print("Função digitada: " + function);
        print("With parameters: " + parameter);
        int parsedValue; //variavel a ser convertida
        bool parsed;     //Variavel a armazenar se a conversão foi bem-sucedida
        switch (function) 
        {
            case KEYBOARD + MOVE_X:
                //Tenta converter de string para inteiro. Caso consiga,
                //retorna true, e parsedValue adota o valor convertido,
                //Caso contrário, exibe uma mensagem de erro de conversão
                parsed = int.TryParse(parameter, out parsedValue); 
                if (parsed)
                    Keyboard_MoveX(parsedValue);
                else
                    Scr_ErrorMessage.ErrorMessage.ShowNewErrorMessage(Scr_Error.PARAMETRO_NOT_INT);
                break;
            case KEYBOARD + MOVE_Y:
                //Tenta converter de string para inteiro. Caso consiga,
                //retorna true, e parsedValue adota o valor convertido,
                //Caso contrário, exibe uma mensagem de erro de conversão
                parsed = int.TryParse(parameter, out parsedValue); //Converte de string para int
                if (parsed)
                    Keyboard_MoveX(parsedValue);
                else
                    Scr_ErrorMessage.ErrorMessage.ShowNewErrorMessage(Scr_Error.PARAMETRO_NOT_INT);
                break;
            default:
                print("Função não encontrada");
                break;
        }
    }


}

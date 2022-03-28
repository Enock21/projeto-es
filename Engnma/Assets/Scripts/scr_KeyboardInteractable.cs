using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class Scr_KeyboardInteractable:MonoBehaviour
{


    [SerializeField]
    protected string className; // Vai servir para identificar a classe digitada no teclado. Cada classe precisa ter um className unico por scene

    public string ClassName { get => className; set => className = value; }


    /**
     * 
     * Importante que todas as funções interagiveis com o teclado comecem com "Keyboard_"
     * */

    //Toda classe interagivel com o teclado deve ter alguma chamada de função, tendo parametro ou não. Essa é a função abstrata que serve como base
    public abstract void CallFunction(string function);

    //Toda classe interagivel com o teclado deve ter alguma chamada de função, tendo parametro ou não. Essa é a função abstrata que serve como base
    public abstract void CallFunction(string function, string parameter);


    //Retorna todas as funções que contem "Keyboard_" no inicio do nome. 
    //Como a classe é derivada do Monobehaviour da Unity, se não tivesse isso apareceriam centenas de funções, e algumas delas poderiam confundir o jogador
    public List<string> GetFunctions()
    {
        List<string> functions = new();
        MethodInfo[] methodInfos = typeof(Scr_NPCInteractable).GetMethods();
        for (int i = 0; i < methodInfos.Length; i++)
        {
            string name = methodInfos[i].Name;
            if (name.Contains(("Keyboard_")))
            {
                functions.Add(name);
            }
        }
        return functions;

    }

    public void PrintFunctions()
    {
        List<string> functions = GetFunctions();

        string msg = "Encontrado objeto: " + ClassName + " com " + functions.Count + " Funções: ";
        if(functions.Count > 0)
        {
            print(functions.ToString());
            string functionsString = "";
            for(int i = 0; i < functions.Count; i++)
            {
                string[] function = functions[i].Split('_');
                print("Index: " + function[1]);
                functionsString += function[1];
                if (i < functions.Count - 1)
                    functionsString += ", ";
            }
            msg += functionsString;
        }
        Scr_Messager.Self.AddMessage(msg);
    }

}

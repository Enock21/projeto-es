using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_InputController : MonoBehaviour
{
    //Atributo est�tico para poder ser encontrado mesmo sem a necessidade de uma instancia.
    //� util para manter a simplicidade e organiza��o em outras classes
    public static Scr_InputController inputController;


    private void Start()
    {
        //Seta o atributo static como a propria classe, para a classe ser encontrada em outras classes sem precisar ser instanciada
        Scr_InputController.inputController = this;
    }

    //Metodo core da classe. Respons�vel por chamar os demais m�todos para fazer v�rias verifica��es, e em seguida chamar o m�todo
    //para chamar a fun��o digitada no teclado virtual.
    public static void NewInput(string input)
    {
        print(input);
        string[] inputWord = input.ToUpper().Split("."); // Toda fun��o deve ser enviada com as letras em maiusculo, pois, nas classes do keyboard interactable
                                                         // as constantes que guardam o nome das classes armazenam o nome em ma�usculo
        string className = inputWord[0];
        Scr_KeyboardInteractable obj = Scr_KeyboardInteractableRepository.Get(className); //Retorna o objeto que possui o mesmo className na Scr_KeyboardInteractableRepository
        List<string> function = inputController.GetFunction(inputWord[1]); // Faz uma verifica��o e separa a fun��o do parametro
        if (!inputController.CheckObjAndFunction(obj, function)) //confirma se o objeto retornado do Scr_KeyboardInteractableRepository e a fun��o s�o validos
        {
            return;
        }
        print("Calling function: " + function[0]);
        inputController.CallFunction(obj, function[0], function[1]); // se todos o objeto retornado e a fun��o passar no CheckObjAndFunction, ent�o, � chamada a fun��o do objeto

    }

    //Confirma se o objeto passado como parametro ou a fun��o s�o nulos. Caso positivo, retorna um erro
    private bool CheckObjAndFunction(Scr_KeyboardInteractable obj, List<string> function)
    {
        if (obj == null)
        {
            Scr_ErrorMessage.ErrorMessage.ShowNewErrorMessage(Scr_Error.OBJETO_NAO_ENCONTRADO);
            return false;
        }
        if (function[0] == null)
        {
            Scr_ErrorMessage.ErrorMessage.ShowNewErrorMessage(Scr_Error.FUNCAO_NAO_ENCONTRADA);
            return false;
        }        
        return true;
    }

    
    //Confirma se o parametro passado no texto digitado � vazio. Caso positivo, � chamada a fun��o sem parametros
    //Caso negativo, � chamada a fun��o com parametro
    public void CallFunction(Scr_KeyboardInteractable obj, string functionString, string parameter)
    {
        if (parameter == "")
            obj.CallFunction("Keyboard_".ToUpper() + functionString);
        else
            obj.CallFunction("Keyboard_".ToUpper() + functionString, parameter);
    }


    //Faz uma divis�o do que � fun��o e do que � o parametro digitado no teclado virtual
    //O retorno � uma lista de string, onde a primeira posi��o � a fun��o e a segunda � o parametro.
    //os parenteses s�o descartados aqui
    private List<string> GetFunction(string functionString)
    {
        List<string> retorno = new List<string>();
        string function = "";
        string parameter = "";
        bool functionEnded = false;
        for(int i = 0; i < functionString.Length; i++)
        {
            bool isParenteses = functionString[i] == '(' || functionString[i] == ')'; //Se encontrar o parenteses, o functionEnded � setado como true, e
                                                                                      //� iniciado a captura do parametro
            if (isParenteses)
                functionEnded = true;

            if (functionEnded && !isParenteses) //Descarta os parenteses e captura o texto digitado antes dos paranteses
                parameter += functionString[i];
            else if (!functionEnded && !isParenteses)//Descarta os parenteses e captura o texto digitado depois dos paranteses
                function += functionString[i];
        }
        print("Function found: " + function); //mostra no console a fun��o encontrada
        print("Parameter found: " + parameter); //mostra no console o parametro encontrado
        retorno.Add(function); //Adiciona a fun��o na lista na primeira posi��o
        retorno.Add(parameter); //Adiciona o parametro na lista na segunda posi��o
        return retorno; //A lista � enfim, retornada 
    }
}

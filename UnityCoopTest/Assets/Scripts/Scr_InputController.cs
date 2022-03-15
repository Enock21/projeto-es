using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_InputController : MonoBehaviour
{
    //Atributo estático para poder ser encontrado mesmo sem a necessidade de uma instancia.
    //É util para manter a simplicidade e organização em outras classes
    public static Scr_InputController inputController;


    private void Start()
    {
        //Seta o atributo static como a propria classe, para a classe ser encontrada em outras classes sem precisar ser instanciada
        Scr_InputController.inputController = this;
    }

    //Metodo core da classe. Responsável por chamar os demais métodos para fazer várias verificações, e em seguida chamar o método
    //para chamar a função digitada no teclado virtual.
    public static void NewInput(string input)
    {
        print(input);
        string[] inputWord = input.ToUpper().Split("."); // Toda função deve ser enviada com as letras em maiusculo, pois, nas classes do keyboard interactable
                                                         // as constantes que guardam o nome das classes armazenam o nome em maíusculo
        string className = inputWord[0];
        Scr_KeyboardInteractable obj = Scr_KeyboardInteractableRepository.Get(className); //Retorna o objeto que possui o mesmo className na Scr_KeyboardInteractableRepository
        List<string> function = inputController.GetFunction(inputWord[1]); // Faz uma verificação e separa a função do parametro
        if (!inputController.CheckObjAndFunction(obj, function)) //confirma se o objeto retornado do Scr_KeyboardInteractableRepository e a função são validos
        {
            return;
        }
        print("Calling function: " + function[0]);
        inputController.CallFunction(obj, function[0], function[1]); // se todos o objeto retornado e a função passar no CheckObjAndFunction, então, é chamada a função do objeto

    }

    //Confirma se o objeto passado como parametro ou a função são nulos. Caso positivo, retorna um erro
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

    
    //Confirma se o parametro passado no texto digitado é vazio. Caso positivo, é chamada a função sem parametros
    //Caso negativo, é chamada a função com parametro
    public void CallFunction(Scr_KeyboardInteractable obj, string functionString, string parameter)
    {
        if (parameter == "")
            obj.CallFunction("Keyboard_".ToUpper() + functionString);
        else
            obj.CallFunction("Keyboard_".ToUpper() + functionString, parameter);
    }


    //Faz uma divisão do que é função e do que é o parametro digitado no teclado virtual
    //O retorno é uma lista de string, onde a primeira posição é a função e a segunda é o parametro.
    //os parenteses são descartados aqui
    private List<string> GetFunction(string functionString)
    {
        List<string> retorno = new List<string>();
        string function = "";
        string parameter = "";
        bool functionEnded = false;
        for(int i = 0; i < functionString.Length; i++)
        {
            bool isParenteses = functionString[i] == '(' || functionString[i] == ')'; //Se encontrar o parenteses, o functionEnded é setado como true, e
                                                                                      //é iniciado a captura do parametro
            if (isParenteses)
                functionEnded = true;

            if (functionEnded && !isParenteses) //Descarta os parenteses e captura o texto digitado antes dos paranteses
                parameter += functionString[i];
            else if (!functionEnded && !isParenteses)//Descarta os parenteses e captura o texto digitado depois dos paranteses
                function += functionString[i];
        }
        print("Function found: " + function); //mostra no console a função encontrada
        print("Parameter found: " + parameter); //mostra no console o parametro encontrado
        retorno.Add(function); //Adiciona a função na lista na primeira posição
        retorno.Add(parameter); //Adiciona o parametro na lista na segunda posição
        return retorno; //A lista é enfim, retornada 
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Keyboard : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField keyboard;
    [SerializeField]
    private Button enterButton;
    [SerializeField]
    private Button cancelButton;
    private bool isFocused;
    private bool isSelected;


    void Update()
    {


        isFocused = keyboard.isFocused; //Conjfirma se o teclado está focado ou não. 
        //Isso é importante principalmente para ativar ou desativar o teclado quando o jogador aperta o botão enter

        //Se o player apertar o botão enter, é chamada a classe input function, e a classe que muda o foco do teclado
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            InputFunction();
            ToggleActivationKeyBoard();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickCancelButton();
        }
        //Chama a classe responsável por definir se o player pode se mover ou não
        SetPlayerMove();

    }


    //Faz uma verificação simples para confirmar se há pelo menos um . e os parenteses no texto digitado no teclado.
    //Caso positivo, envia o texto para a classe InputController.
    //Caso negativo, mostra uma mensagem de erro no console
    void InputFunction()
    { 
        string text = keyboard.text;
        if (CheckText(text))
            Scr_InputController.NewInput(text);
        else if (text != "")
            Scr_ErrorMessage.ErrorMessage.ShowNewErrorMessage(Scr_Error.COMANDO_INVALIDO);
        keyboard.text = "";
        return;
        
        
    }

    //Se o teclado estiver no foco para digitação, o player não pode se mover
    //Essa classe desabilida ou habilita a funcionalidade do jogador andar dependendo se o teclado está em foco ou não
    void SetPlayerMove()
    {
        bool canPlayerMove = true;
        if (keyboard.isFocused)
        {
            canPlayerMove = false;
        }
        Scr_PlayerSettings.CanPlayerMove = canPlayerMove;
    }

    //Troca o status do foco do teclado. Se estiver sem foco, passa a ter, e se tiver passa a não ter
    void ToggleActivationKeyBoard()
    {
        if (!isSelected && !isFocused)
        {
            ActiveKeyboard();
        }
        if (!isFocused && isSelected)
        {
            DesactiveKeyboard();
        }
    }

    void ActiveKeyboard()
    {
        keyboard.ActivateInputField();
    }
    public void DesactiveKeyboard()
    {
        /*keyboard.interactable = false;
        keyboard.interactable = true;*/
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    //Faz uma checagem simples. Se o player digitou um ponto e os parenteses, então o texto digitado é valido.
    //O texto deve ter os parentes na ordem "()", podendo ter algo escrito dentro dele, ou não
    private bool CheckText(string text)
    {
        string[] textSplited = text.Split('.');
        
        if (textSplited.Length != 2 || textSplited[0].Length == 0 || textSplited[1].Length == 0)
            return false;

        bool leftParantesis = false;
        bool righParentesis = false;
        string function = textSplited[1];
        for (int i = 0; i < function.Length; i++)
        {
            //Se encontrar o parenteses esquerdo entra no bloco de comandos abaixo
            if(function[i] == '(')
            {

                //Se não encontrou o parenteses antes, seta como true
                if (!leftParantesis)
                    leftParantesis = true;
                //Se encontrou, então retorna false e encerra a função. 
                else
                    return false;
            }
            
            //Se encontrar o parenteses direito entra no bloco de comandos abaixo
            if (function[i] == ')')
            {
                //Se o parenteses esquerdo não foi encontrado ainda, retorna false e encerra a função
                if (!leftParantesis)
                    return false;
                //Se não encontrou o parenteses antes, seta como true
                if (!righParentesis)
                    righParentesis = true;
                //Se encontrou, então retorna false e encerra a função. 
                else
                    return false;
            }
                
        }
        if (!leftParantesis || !righParentesis)
            return false;
        
        return true;
    }

    public void SetSelected()
    {
        isSelected = true;
    }

    public void SetDeselected()
    {
        isSelected = false;
    }

    //Função que é executada quando o jogador aperta o botão virtual enter do teclado.
    //Deve ser a mesma coisa quando o jogador aperta o botão enter de seu teclado físico
    public void OnClickEnterButton()
    {
        InputFunction();
        ToggleActivationKeyBoard();
    }

    //Função que é executada quando o jogador aperta o botão virtual ESC do teclado.
    //Deve ser a mesma coisa quando o jogador aperta o botão ESC de seu teclado físico
    public void OnClickCancelButton()
    {
        keyboard.text = "";
        DesactiveKeyboard();
    }

    
}

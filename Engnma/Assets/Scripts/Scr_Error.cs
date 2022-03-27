using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Essa classe vai armazenar todas as mensagens de erro exibidas
public static class Scr_Error
{
    //Caso o objeto digitado pelo player n�o seja encontrado
    public static string OBJETO_NAO_ENCONTRADO = "O objeto encontrado n�o � v�lido"; 
    //Caso a fun��o digitada pelo player n�o seja encontrada
    public static string FUNCAO_NAO_ENCONTRADA = "N�o possui essa fun��o";
    //Caso o que o player digite seja algo aleat�rio e sem sentido
    public static string COMANDO_INVALIDO = "O comando digitado n�o � valido";

    /*
     * Erros de parametro
     */
    //Caso o par�metro digitado n�o seja convertivel para inteiro
    public static string PARAMETRO_NOT_INT = "O par�metro digitado n�o � do tipo inteiro";
    //Caso o par�metro digitado n�o seja convertivel para inteiro
    public static string PARAMETRO_NOT_FLOAT = "O par�metro digitado n�o � do tipo float";
    //Caso o player n�o digite o par�metro para uma fun��o que necessite de par�metro
    public static string PARAMETRO_EMPTY = "A fun��o usada necessida de par�metros n�o vazios";

    
}
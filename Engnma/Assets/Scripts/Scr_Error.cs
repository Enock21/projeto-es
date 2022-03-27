using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Essa classe vai armazenar todas as mensagens de erro exibidas
public static class Scr_Error
{
    //Caso o objeto digitado pelo player não seja encontrado
    public static string OBJETO_NAO_ENCONTRADO = "O objeto encontrado não é válido"; 
    //Caso a função digitada pelo player não seja encontrada
    public static string FUNCAO_NAO_ENCONTRADA = "Não possui essa função";
    //Caso o que o player digite seja algo aleatório e sem sentido
    public static string COMANDO_INVALIDO = "O comando digitado não é valido";

    /*
     * Erros de parametro
     */
    //Caso o parâmetro digitado não seja convertivel para inteiro
    public static string PARAMETRO_NOT_INT = "O parâmetro digitado não é do tipo inteiro";
    //Caso o parâmetro digitado não seja convertivel para inteiro
    public static string PARAMETRO_NOT_FLOAT = "O parâmetro digitado não é do tipo float";
    //Caso o player não digite o parâmetro para uma função que necessite de parâmetro
    public static string PARAMETRO_EMPTY = "A função usada necessida de parâmetros não vazios";

    
}
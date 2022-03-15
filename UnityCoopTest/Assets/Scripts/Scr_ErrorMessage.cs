using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scr_ErrorMessage : MonoBehaviour
{
    //Armazena pai do objeto que possui o texto para mensagem de erro
    [SerializeField] //Permite que seja editado via Editor
    private GameObject messageErrorGameObject;
    //Armazena o componente de texto onde irá ser exibida a mensagem de erro
    [SerializeField]
    private TextMeshProUGUI text; //Permite que seja editado via Editor
    //Variavel estatica para armazenar a si mesmo e ser chamada estaticamente
    private static Scr_ErrorMessage errorMessage;

    //Tempo em segundos em que a mensagem de erro vai ser exibida
    [SerializeField] //Permite que seja editado via Editor
    private float timeError;
    //O total de tempo restante para a mensagem ser exibida
    private float actualTimerError;

    //true -> está exibindo mensagem de erro
    //false -> não está exibindo mensagem de erro
    private bool hasErrorToShow;

    //Mensagem que será exibida
    private string message;
    //Encapsulamento de variaveis
    public static Scr_ErrorMessage ErrorMessage { get => errorMessage; set => errorMessage = value; }

    // Start is called before the first frame update
    void Start()
    {
        actualTimerError = 0;
        hasErrorToShow = false;
        //Aponta para si mesmo, permitindo ser chamado de qualquer classe com facilidade
        errorMessage = this; 
    }

    // Update is called once per frame
    void Update()
    {
        ShowMessage();
    }

    //Verifica se há mensagem para ser exibida, se sim, decresce o tempo do actualTimeError,
    //E se o actualTimeError for esgotado, desativa a mensagem exibida
    private void ShowMessage()
    {
        if (hasErrorToShow)
        {
            actualTimerError -= Time.deltaTime;
            if(actualTimerError <= 0)
            {
                HideErrorMessage();
            }
        }
    }

    //Recebe uma nova mensagem para ser exibida. Após isso,
    //Ativa o gameObject da mensagem pela quantidade de tempo definida no timeError, mostrando o erro
    public void ShowNewErrorMessage(string message)
    {
        actualTimerError = timeError;
        hasErrorToShow = true;
        this.message = message;
        messageErrorGameObject.SetActive(true);
        text.text = this.message;
    }

    //Esconde o erro da mensagem, e desativa o objeto pai que tem o mensageError como filho.
    //Também seta o conteudo da string message para vazio
    public void HideErrorMessage()
    {
        hasErrorToShow = false;
        this.message = "";
        messageErrorGameObject.SetActive(false);
    }

    
}

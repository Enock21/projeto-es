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
    }

    private void Update()
    {
        
    }

    public void AddMessage(string message)
    {
        texts[0].text += "\n" + message;

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
}

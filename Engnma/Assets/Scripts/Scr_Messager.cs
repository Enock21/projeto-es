using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scr_Messager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] texts;

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

    public void AddMessage(string message)
    {
        int length = texts.Length;
        for (int i = 0; i < length - 1; i++)
        {
            texts[i].text = texts[i + 1].text;
        }
        texts[length - 1].text = message;
    }

    public void CleanScreen()
    {
        int length = texts.Length;
        for (int i = 0; i < length; i++)
        {
            texts[i].text = "";
        }
    }
}

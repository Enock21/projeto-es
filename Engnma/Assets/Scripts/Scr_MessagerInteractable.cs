using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MessagerInteractable : Scr_KeyboardInteractable
{
    private const string CLEAR = "CLEAR";
    private const string HELP = "HELP";
    private static Scr_MessagerInteractable self;

    public static Scr_MessagerInteractable Self { get => self; set => self = value; }

    // Start is called before the first frame update
    void Awake()
    {
        Scr_MessagerInteractable.self = this;

    }

    void Start()
    {
        Scr_KeyboardInteractableRepository.AddCollider(this);
    }

    public override void CallFunction(string function)
    {
        print("Função digitada: " + function);
        switch (function)
        {
            case KEYBOARD + CLEAR:
                Scr_Messager.Self.CleanScreen();
                break;
            case KEYBOARD + HELP:
                Scr_Messager.Self.Help();
                break;
            default:
                Scr_Messager.Self.AddMessage("<b>Console</b>: " + Scr_Error.FUNCAO_NAO_ENCONTRADA);
                break;
        }
    }

    public override void CallFunction(string function, string parameter)
    {
        print("Função digitada: " + function);
        switch (function)
        {
            default:
                Scr_Messager.Self.AddMessage("<b>Console</b>: " + Scr_Error.FUNCAO_NAO_ENCONTRADA);
                break;
        }
    }

}

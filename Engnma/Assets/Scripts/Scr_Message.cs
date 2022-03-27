using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Message : MonoBehaviour
{
    [SerializeField]
    private Text textUI;

    public string Text { get => textUI.text; set => textUI.text = value;  }


}

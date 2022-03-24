using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void awake()
    {
        instance = this;
    }

    public event Action onNpcTriggerEnter;
    public FloatingTextManager floatingTextManager;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }

    public void NpcTriggerEnter()
    {
        if (onNpcTriggerEnter != null)
        {
            onNpcTriggerEnter();
        }
    }
}

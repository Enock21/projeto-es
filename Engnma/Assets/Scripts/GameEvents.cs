using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void awake()
    {
        current = this;
    }

    public event Action onNpcTriggerEnter;

    public void NpcTriggerEnter()
    {
        if (onNpcTriggerEnter != null)
        {
            onNpcTriggerEnter();
        }
    }
}

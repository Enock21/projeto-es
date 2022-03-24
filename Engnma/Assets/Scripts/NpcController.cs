using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.instance.onNpcTriggerEnter += OnNpcInteraction;
    }

    private void OnNpcInteraction()
    {
        if (GameEvents.instance != null){
            Debug.Log(GameEvents.instance);
        }
    }
}

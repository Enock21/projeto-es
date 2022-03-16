using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.onNpcTriggerEnter += OnNpcInteraction;
    }

    private void OnNpcInteraction()
    {
        if (GameEvents.current != null){
            Debug.Log(GameEvents.current);
        }
    }
}

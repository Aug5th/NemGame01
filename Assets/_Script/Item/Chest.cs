using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MyMonoBehaviour, IInteractable
{
    [SerializeField] private bool interacting;

    public void Interact()
    {
        Open();
    }

    private void Open()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interacting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interacting = false;
        }
    }
}

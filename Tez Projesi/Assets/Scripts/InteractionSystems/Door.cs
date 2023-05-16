using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPromt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Door");
        return true;
    }
}

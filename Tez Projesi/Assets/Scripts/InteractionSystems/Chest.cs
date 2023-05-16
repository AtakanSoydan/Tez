using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPromt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Chest");
        return true;
    }
}

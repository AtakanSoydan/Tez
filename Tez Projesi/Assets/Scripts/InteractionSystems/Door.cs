using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPromt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasKey)
        {
            Debug.Log("Opening Door");
            inventory.HasKey = false;
            return true;
        }

        Debug.Log("No Key Found");
        return false;
   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private bool canActivate = false; //This bool is letting us activation of object...
    private GameObject childObject; 
    private GameObject grandchildObject; 

    private GameObject buttonObject;
    private bool isActive = false; 

    private void Start()
    {
        childObject = transform.GetChild(0).gameObject; // Pick child object...
        grandchildObject = childObject.transform.GetChild(0).gameObject; //Pick child object of child object...
        grandchildObject.SetActive(false); // Invisible on start...

        buttonObject = childObject.transform.GetChild(1).gameObject;
        buttonObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = true; // Allow activating the object upon collision with the collider...
            buttonObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = false; // Do not allow activating the object upon leaving the collider.
            grandchildObject.SetActive(false);
            buttonObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.F)) // When allowed to activate the object and the 'F' key is pressed
        {
            isActive = !isActive;

            if (isActive)
            {
                grandchildObject.SetActive(true);
            }
            else
            {
                grandchildObject.SetActive(false); 
            }    
        }
    }
}

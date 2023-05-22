using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private bool canActivate = false; // Objeyi aktifle�tirmeye izin veren bayrak
    private GameObject childObject; // G�r�n�rl��� de�i�tirilecek child obje
    private GameObject grandchildObject; // Child objenin child objesi

    private GameObject buttonObject;
    private bool isActive = false;

    private void Start()
    {
        childObject = transform.GetChild(0).gameObject; // Child objeyi al
        grandchildObject = childObject.transform.GetChild(0).gameObject; // Child objenin child objesini al
        grandchildObject.SetActive(false); // Ba�lang��ta g�r�nmez yap

        buttonObject = childObject.transform.GetChild(1).gameObject;
        buttonObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = true; // Collider'a �arpma durumunda objeyi aktifle�tirmeye izin ver
            buttonObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = false; // Collider'dan ayr�lma durumunda objeyi aktifle�tirmeye izin verme
            grandchildObject.SetActive(false);
            buttonObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.F)) // Objeyi aktifle�tirmeye izin verildi�inde ve "F" tu�una bas�ld���nda
        {
            isActive = !isActive;

            if (isActive)
            {
                grandchildObject.SetActive(true); // Grandchild objeyi g�r�n�r yap     
            }
            else
            {
                grandchildObject.SetActive(false); // Grandchild objeyi g�r�n�r yap     
            }    
        }
    }
}

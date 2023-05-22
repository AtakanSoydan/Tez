using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private bool canActivate = false; // Objeyi aktifleþtirmeye izin veren bayrak
    private GameObject childObject; // Görünürlüðü deðiþtirilecek child obje
    private GameObject grandchildObject; // Child objenin child objesi

    private GameObject buttonObject;
    private bool isActive = false;

    private void Start()
    {
        childObject = transform.GetChild(0).gameObject; // Child objeyi al
        grandchildObject = childObject.transform.GetChild(0).gameObject; // Child objenin child objesini al
        grandchildObject.SetActive(false); // Baþlangýçta görünmez yap

        buttonObject = childObject.transform.GetChild(1).gameObject;
        buttonObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = true; // Collider'a çarpma durumunda objeyi aktifleþtirmeye izin ver
            buttonObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = false; // Collider'dan ayrýlma durumunda objeyi aktifleþtirmeye izin verme
            grandchildObject.SetActive(false);
            buttonObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.F)) // Objeyi aktifleþtirmeye izin verildiðinde ve "F" tuþuna basýldýðýnda
        {
            isActive = !isActive;

            if (isActive)
            {
                grandchildObject.SetActive(true); // Grandchild objeyi görünür yap     
            }
            else
            {
                grandchildObject.SetActive(false); // Grandchild objeyi görünür yap     
            }    
        }
    }
}

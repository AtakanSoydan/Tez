using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private bool canActivate = false; // Objeyi aktifleştirmeye izin veren bayrak
    private GameObject childObject; // Görünürlüğü değiştirilecek child obje
    private GameObject grandchildObject; // Child objenin child objesi

    private GameObject buttonObject;
    private bool isActive = false;

    private void Start()
    {
        childObject = transform.GetChild(0).gameObject; // Child objeyi al
        grandchildObject = childObject.transform.GetChild(0).gameObject; // Child objenin child objesini al
        grandchildObject.SetActive(false); // Başlangıçta görünmez yap

        buttonObject = childObject.transform.GetChild(1).gameObject;
        buttonObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = true; // Collider'a çarpma durumunda objeyi aktifleştirmeye izin ver
            buttonObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canActivate = false; // Collider'dan ayrılma durumunda objeyi aktifleştirmeye izin verme
            grandchildObject.SetActive(false);
            buttonObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.F)) // Objeyi aktifleştirmeye izin verildiğinde ve "F" tuşuna basıldığında
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

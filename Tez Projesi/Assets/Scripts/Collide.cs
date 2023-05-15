using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            var a = other.gameObject.transform.GetChild(0).gameObject;
            a.SetActive(true);
            Debug.Log("UI Activated.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            var a = other.gameObject.transform.GetChild(0).gameObject;
            a.SetActive(false);
            Debug.Log("UI Deactivated.");
        }
    }
}

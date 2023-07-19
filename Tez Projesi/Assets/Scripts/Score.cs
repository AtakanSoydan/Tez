using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int collectedInfo = 0;
    [SerializeField] private TMP_Text infoScoreText;
    [SerializeField] private GameObject progressBarGreen;
    [SerializeField] private GameObject testButtonActivation;

    private bool takenInfo = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            takenInfo = true;
        }
    }
    private void Update()
    {
        if (takenInfo && Input.GetKeyDown(KeyCode.F) && gameObject.CompareTag("Ground") && collectedInfo < 7)
        {
            Debug.Log("collected info arttýrýlmadan önce: " + collectedInfo);
            collectedInfo++;
            //GameData.levelScore += 75;
            infoScoreText.text = collectedInfo.ToString();
            progressBarGreen.transform.GetChild(collectedInfo - 1).gameObject.SetActive(true);
            Debug.Log("collected info arttýrýldýktan sonra: " + collectedInfo);

            gameObject.tag = "Collected";

            if (collectedInfo == 4)
            {
                testButtonActivation.SetActive(true);
            }

            if (collectedInfo == 7)
            {
                //GameData.levelScore += 100;
            }
        }
        else
        {
            Debug.Log("Toplanan tüm info: " + collectedInfo);
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            takenInfo = false;
        }
    }

    
}

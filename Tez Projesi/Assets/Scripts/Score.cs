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
        if (takenInfo && Input.GetKeyDown(KeyCode.F) && gameObject.CompareTag("Ground") && this.collectedInfo < GameData.totalInfo )
        {
            
            Debug.Log("collected info arttýrýlmadan önce: " + collectedInfo);
            this.collectedInfo++;
            GameData.levelScore += 75;
            infoScoreText.text = this.collectedInfo.ToString();
            progressBarGreen.transform.GetChild(this.collectedInfo - 1).gameObject.SetActive(true);
            Debug.Log("collected info arttýrýldýktan sonra: " + collectedInfo);

            gameObject.tag = "Collected";

            if (this.collectedInfo == 4)
            {
                testButtonActivation.SetActive(true);
            }

            if (this.collectedInfo == 7)
            {
                GameData.levelScore += 100;
            }
        }
        else
        {
            Debug.Log("Toplanan tüm info: " + this.collectedInfo);
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

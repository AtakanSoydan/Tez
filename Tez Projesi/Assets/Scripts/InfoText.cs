using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoText : MonoBehaviour
{
    private int infoCount = 0;
    private TextMeshProUGUI infoCountText;

    private void Awake()
    {
        infoCountText = this.GetComponent<TextMeshProUGUI>();
    }
}

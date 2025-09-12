using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cornerResultText;
    [SerializeField] private TextMeshProUGUI timeResultText;

    void Start()
    {
        cornerResultText.text = GameData.cornerHitCount.ToString();

        int minutes = Mathf.FloorToInt(GameData.elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(GameData.elapsedTime % 60f);
        timeResultText.text = string.Format("{0}:{1:00}", minutes, seconds);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (!CountDown.isFinished)
        {
            return;
        }
        
        GameData.elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(GameData.elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(GameData.elapsedTime % 60f);

        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}

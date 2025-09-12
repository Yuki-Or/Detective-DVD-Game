using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CornerHitController : MonoBehaviour
{
    public string objTag = "Face";
    public int cornerHitCount = 0;

     [SerializeField] private TextMeshProUGUI cornerHitText;

    public void AddCornerHit()
    {
        cornerHitCount++;
        GameData.cornerHitCount = cornerHitCount;
        
        if (cornerHitText != null)
        {
            cornerHitText.text = "角ヒット: " + cornerHitCount;
        }
        Debug.Log("Corner hits: " + cornerHitCount);
    }
}

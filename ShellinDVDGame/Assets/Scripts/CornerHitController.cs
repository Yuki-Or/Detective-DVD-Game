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
        if (cornerHitText != null)
        {
            cornerHitText.text = "Corner Hits: " + cornerHitCount;
        }
        Debug.Log("Corner hits: " + cornerHitCount);
    }
}

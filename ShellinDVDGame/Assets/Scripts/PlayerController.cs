using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour,  IDragHandler
{
    private RectTransform rt;
    private string faceTag = "Face";

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rt.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        rt.anchoredPosition = localPoint;
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(faceTag))
        {
            Debug.Log("負けました！");
            SceneManager.LoadScene("ResultScene");
        }
    }
}

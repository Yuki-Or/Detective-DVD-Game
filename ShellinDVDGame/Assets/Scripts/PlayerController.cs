using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDragHandler
{
    private RectTransform rt;
    private string faceTag = "Face";

    [SerializeField] private RectTransform boundary; 

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

        Vector2 newPos = localPoint;

        Vector3[] corners = new Vector3[4];
        boundary.GetWorldCorners(corners);

        float halfWidth = rt.rect.width * 0.5f;
        float halfHeight = rt.rect.height * 0.5f;

        Vector3 min = rt.parent.InverseTransformPoint(corners[0]);
        Vector3 max = rt.parent.InverseTransformPoint(corners[2]);

        newPos.x = Mathf.Clamp(newPos.x, min.x + halfWidth, max.x - halfWidth);
        newPos.y = Mathf.Clamp(newPos.y, min.y + halfHeight, max.y - halfHeight);

        rt.anchoredPosition = newPos;
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

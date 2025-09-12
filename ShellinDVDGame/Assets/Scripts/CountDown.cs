using System.Collections;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;
    public float interval = 1f;

    public static bool isFinished = false;

    void Start()
    {
        isFinished = false;
        StartCoroutine(StartCountDown());
    }

    private IEnumerator StartCountDown()
    {
        string[] texts = { "3", "2", "1", "GO!" };

        for (int i = 0; i < texts.Length; i++)
        {
            countDownText.text = texts[i];
            yield return new WaitForSeconds(interval);
        }

        countDownText.text = "";
        isFinished = true;       
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FaceMovementController : MonoBehaviour
{
    private float speed = 50f;
    private float speedIncrement = 50f;
    private float interval = 10f;
    private float max_speed = 400f;
    private Rigidbody2D rb;
    private Image img;

    private bool isStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        img = GetComponent<Image>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeColorRandomly();
        }
    }

    private void ChangeColorRandomly()
    {
        img.color = new Color(Random.value, Random.value, Random.value);
    }

    void Update()
    {

        if (!isStarted && CountDown.isFinished)
        {
            StartMovement();
        }
    }

    private void StartMovement()
    {
        isStarted = true;

        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = dir * speed;

        StartCoroutine(IncreaseSpeedOverTime());
    }

    private IEnumerator IncreaseSpeedOverTime()
    {
        while (speed < max_speed)
        {
            yield return new WaitForSeconds(interval);

            Vector2 direction = rb.velocity.normalized;
            speed += speedIncrement;
            rb.velocity = direction * speed;

            Debug.Log($"speed is now {speed}");
        }
    }
}

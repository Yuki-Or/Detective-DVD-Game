using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FaceMovementController : MonoBehaviour
{
    private float speed = 100f;
    private float speedIncrement = 50f;
    private float interval = 10f;
    private float max_speed = 400f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.freezeRotation = true;
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

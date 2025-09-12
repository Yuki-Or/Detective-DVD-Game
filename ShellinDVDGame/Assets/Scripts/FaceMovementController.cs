using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMovementController : MonoBehaviour
{
    private float speed = 100f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;
        rb.velocity = dir * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerCollider : MonoBehaviour
{
    private CornerHitController controller;

    void Start()
    {
        controller = FindObjectOfType<CornerHitController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(controller.objTag))
        {
            controller.AddCornerHit();
        }
    }
}

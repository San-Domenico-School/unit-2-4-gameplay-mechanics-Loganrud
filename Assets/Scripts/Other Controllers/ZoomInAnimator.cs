using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInAnimator : MonoBehaviour
{
    private Vector3 desiredScale;
    private Vector3 initialScale = Vector3.one.normalized;
    private float zoomInRate = 1.06f;
    private float zoomInFrequency = 0.03f;

    // Store the desired scale, set the initial scale, and then call ZoomIn
    private void OnEnable()
    {
        desiredScale = transform.localScale;
        transform.localScale = initialScale;
        InvokeRepeating("ZoomIn", 0, zoomInFrequency);
    }
 
    // Resets the current scale to the desired scale
    private void OnDisable()
    {
        transform.localScale = desiredScale;
    }

    // Slowly grow the scale from initial to desired
    private void ZoomIn()
    {
        if (transform.localScale.magnitude <  desiredScale.magnitude)
        {
            transform.localScale *= zoomInRate;
        }
        else
        {
            CancelInvoke();
        }
    }
}

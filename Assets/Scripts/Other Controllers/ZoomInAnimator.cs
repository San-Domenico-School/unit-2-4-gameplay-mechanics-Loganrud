using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInAnimator : MonoBehaviour
{
    private Vector3 desiredScale;
    private Vector3 initialScale = Vector3.one.normalized;
    private float zoomInRate = 1.06f;
    private float zoomInFrequency = 0.03f;

    // Start is called before the first frame update
    private void OnEnable()
    {
        desiredScale = transform.localScale;
        initialScale = transform.localScale;
        InvokeRepeating
    }

    // Update is called once per frame
    private void OnDisable()
    {
        
    }

    private void ZoomIn()
    {

    }
}

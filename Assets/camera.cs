using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform Target;
    public float smoothing = 5f;
    Vector3 offset;
   
    private void Start()
    {
        offset = transform.position - Target.position;
    }
    private void FixedUpdate()
    {

        Vector3 targetCamPos = Target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

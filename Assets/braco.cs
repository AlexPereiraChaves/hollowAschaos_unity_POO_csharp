using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class braco : MonoBehaviour
{
    

    int limtChao;
    Rigidbody rigidy;
    
    public Transform Target;
    public float smoothing = 5f;
    Vector3 offset;
    private void Start()
    {
        offset = transform.position - Target.position;
    }
    private void Update()
    {
        rigidy = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        Vector3 targetCamPos = Target.position + offset;
       
        transform.position = Vector3.Lerp(transform.position, targetCamPos,10f*Time.deltaTime);
       /* Quaternion novaRotacao = Quaternion.LookRotation(targetCamPos);
        rigidy.MoveRotation(novaRotacao);*/
    }
   
}

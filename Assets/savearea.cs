using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savearea : MonoBehaviour
{
    public bool Cam = false;
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 30 * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cam = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cam = false;
        }
    }
}

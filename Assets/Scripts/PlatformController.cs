using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Vector3 previousPosition;

    public Vector3 movement; // Dirección de movimiento (puedes animarla o cambiarla dinámicamente)

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        transform.position += movement * Time.deltaTime;
    }

    public Vector3 GetPlatformDelta()
    {
        Vector3 delta = transform.position - previousPosition;
        previousPosition = transform.position;
        return delta;
    }
}

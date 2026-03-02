using UnityEngine;

public class RotateIndefinitely : MonoBehaviour
{
    public float rotationSpeed = 20f;  // Velocidad de rotación (grados por segundo)
    public Vector3 rotationAxis = Vector3.up;  // Eje sobre el que rotará (por defecto Y)

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
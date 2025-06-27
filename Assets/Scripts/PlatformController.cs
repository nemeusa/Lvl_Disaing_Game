using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private bool isOnPlatform = false;
    private Transform platformTransform;

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobamos si el jugador está en contacto con la plataforma
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = true;
            platformTransform = collision.transform;  // Guardamos la referencia de la plataforma
            transform.SetParent(platformTransform);   // Hacemos al jugador hijo de la plataforma
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = false;
            platformTransform = null;  // Limpiamos la referencia cuando el jugador sale de la plataforma
            transform.SetParent(null);  // El jugador deja de ser hijo de la plataforma
        }
    }

    private void Update()
    {
        // Si el jugador está en la plataforma y no tiene movimiento independiente, puede ser controlado por la plataforma
        if (isOnPlatform && platformTransform != null)
        {
            // Si la plataforma se mueve, el jugador debería moverse junto con ella
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}

using UnityEngine;
using StarterAssets;

public class Gravity : MonoBehaviour
{
    [Header("Zona de Gravedad")]
    [Tooltip("Gravedad que se aplica cuando el jugador entra en la zona.")]
    [SerializeField] private float zoneGravity = -10f; // Gravedad específica de esta zona

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            FirstPersonController playerController = other.GetComponent<FirstPersonController>();
            if (playerController != null)
            {
                playerController.SetGravity(zoneGravity); // Cambiar la gravedad del jugador
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el objeto que sale es el jugador
        if (other.CompareTag("Player"))
        {
            FirstPersonController playerController = other.GetComponent<FirstPersonController>();
            if (playerController != null)
            {
                playerController.ResetGravity(); // Restaurar la gravedad normal
            }
        }
    }
}
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light directionalLight; // Drag your Directional Light here

    void Start()
    {
        if (directionalLight != null)
            directionalLight.enabled = false; // Light starts off
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure player is tagged
        {
            if (directionalLight != null)
                directionalLight.enabled = true; // Turn on
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (directionalLight != null)
                directionalLight.enabled = false; // Turn off
        }
    }
}
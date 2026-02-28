using UnityEngine;

public class TriggerBubble : MonoBehaviour
{
    public GameObject objetoObjetivo;
    public bool activar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoObjetivo.SetActive(activar);
        }
    }
}
using UnityEngine;

public class TriggerBubble : MonoBehaviour
{
    public GameObject objetoObjetivo;
    //public bool activar;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoObjetivo.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoObjetivo.SetActive(false);
        }
    }
}
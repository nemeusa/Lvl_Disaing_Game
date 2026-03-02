using UnityEngine;

public class LightColorChanger : MonoBehaviour
{
    // Tiempo que tarda en cambiar completamente el color
    public float changeSpeed = 1.0f;
    public Light directionalLight;
    public Color targetColor;

    void Start()
    {
        // Obtener la luz direccional
        directionalLight = GetComponent<Light>();

        // Establecer el color objetivo inicial (puede ser cualquier color inicial)
        targetColor = new Color(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        // Cambiar el color de la luz lentamente hacia el color objetivo
        directionalLight.color = Color.Lerp(directionalLight.color, targetColor, changeSpeed * Time.deltaTime);

        // Si el color actual se aproxima al color objetivo, establecer un nuevo color aleatorio
        if (Vector4.Distance(directionalLight.color, targetColor) < 0.01f)
        {
            targetColor = new Color(Random.value, Random.value, Random.value);
        }
    }
}
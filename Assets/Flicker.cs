using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flicker : MonoBehaviour
{
    public Image fadeImage;  // Imagen negra de UI
    public int blinkCount = 2;  // Número de parpadeos
    public float blinkDuration = 0.3f;  // Duración de cada parpadeo
    public float timeBetweenBlinks = 0.1f;  // Tiempo entre parpadeos

    private bool isBlinking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isBlinking)  // Detecta el click
        {
            StartCoroutine(BlinkScreen());
        }
    }

    IEnumerator BlinkScreen()
    {
        isBlinking = true;

        for (int i = 0; i < blinkCount; i++)
        {
            // Parpadeo a negro
            yield return StartCoroutine(Fade(0f, 1f));
            // Esperar un pequeño intervalo
            yield return new WaitForSeconds(timeBetweenBlinks);
            // Parpadeo a transparente
            yield return StartCoroutine(Fade(1f, 0f));

            // Si no es el último parpadeo, espera entre ellos
            if (i < blinkCount - 1)
                yield return new WaitForSeconds(timeBetweenBlinks);
        }

        isBlinking = false;

        // Desactiva el objeto después de ejecutar el parpadeo
        gameObject.SetActive(false);
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < blinkDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / blinkDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(color.r, color.g, color.b, endAlpha);  // Asegura que termine con el valor correcto
    }
}
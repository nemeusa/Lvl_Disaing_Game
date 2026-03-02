using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CambiarSkybox: MonoBehaviour
{
    public Material nuevoSkybox;
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;
            StartCoroutine(CambiarSkyboxConFade());
        }
    }

    IEnumerator CambiarSkyboxConFade()
    {
        // Fade a negro
        yield return StartCoroutine(Fade(0, 1));

        // Cambiar Skybox
        RenderSettings.skybox = nuevoSkybox;
        DynamicGI.UpdateEnvironment();

        // Fade desde negro
        yield return StartCoroutine(Fade(1, 0));
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flicker : MonoBehaviour
{
    public Image fadeImage;  // Imagen negra de UI
    public int blinkCount = 2;  // Número de parpadeos
    public float blinkDuration = 0.3f;  // Duración de cada parpadeo
    public float timeBetweenBlinks = 0.1f;  // Tiempo entre parpadeos
    public GameObject targetObject;  
    private bool isBlinking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isBlinking)  
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))  
            {
                if (hit.collider.gameObject == targetObject)
                {
                    StartCoroutine(BlinkScreen());  
                }
            }
        }
    }

    IEnumerator BlinkScreen()
    {
        isBlinking = true;

        for (int i = 0; i < blinkCount; i++)
        {
            yield return StartCoroutine(Fade(0f, 1f));
            yield return new WaitForSeconds(timeBetweenBlinks);
            yield return StartCoroutine(Fade(1f, 0f));

            if (i < blinkCount - 1)
                yield return new WaitForSeconds(timeBetweenBlinks);
        }

        isBlinking = false;

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

        fadeImage.color = new Color(color.r, color.g, color.b, endAlpha);  
    }
}
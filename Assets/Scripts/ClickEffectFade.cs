using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class ClickEffectFade : MonoBehaviour
{
    public float lifetime = 2f;
    public float fadeDuration = 1f;

    //add three audioclips for different click sounds


    private UnityEngine.UI.Image sprite;

    void Awake()
    {
        sprite = GetComponent<UnityEngine.UI.Image>();
        StartCoroutine(FadeOut());

    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(lifetime - fadeDuration);

        float t = 0f;
        Color startColor = sprite.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            sprite.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                alpha
            );
            yield return null;
        }

        Destroy(gameObject);
    }
}
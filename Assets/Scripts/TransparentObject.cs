using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{

    [Range(0, 1)]
    [SerializeField] private float transparencyValue = 0.7f;
    [SerializeField] private float transparencyFadeTime = 0.4f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            StartCoroutine(FadeTree(spriteRenderer, transparencyFadeTime, spriteRenderer.color.a, transparencyValue));
        }
    }


    private IEnumerator FadeTree(SpriteRenderer spriteTransparecy, float fadeTime, float startValue,
        float targetTransparency)
    {
        float timeElapsed = 0;
        while(timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparency, timeElapsed/fadeTime);
            spriteTransparecy.color = new Color(spriteTransparecy.color.r , spriteTransparecy.color.b,
                spriteTransparecy.color.g, newAlpha);
            yield return null;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            StartCoroutine(FadeTree(spriteRenderer, transparencyFadeTime, spriteRenderer.color.a, 1f));
        }
    }
}

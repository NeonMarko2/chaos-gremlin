using System.Collections;
using UnityEngine;

public class FlashSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SpriteRenderer;

    public void Flash()
    {
        StartCoroutine(Flasher());
    }

    IEnumerator Flasher()
    {
        SpriteRenderer.material.SetFloat("_FlashOpacity", 1);
        yield return new WaitForSeconds(.1f);
        SpriteRenderer.material.SetFloat("_FlashOpacity", 0);
    }
}

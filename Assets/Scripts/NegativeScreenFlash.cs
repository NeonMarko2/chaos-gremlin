using System;
using System.Collections;
using UnityEngine;

public class NegativeScreenFlash : MonoBehaviour
{
    [SerializeField] private Material ScreenFlashMaterial;
    public event Action FlashFinished;

    public void StartScreenFlash(float flashDuration)
    {
        StartCoroutine(ScreenFlash(flashDuration));
    }

    IEnumerator ScreenFlash(float flashDuration)
    {
        ScreenFlashMaterial.SetInt("_Active", 1);
        yield return new WaitForSeconds(flashDuration / 2);
        ScreenFlashMaterial.SetInt("_InvertColor", 1);
        yield return new WaitForSeconds(flashDuration / 2);
        ScreenFlashMaterial.SetInt("_Active", 0);
        ScreenFlashMaterial.SetInt("_InvertColor", 0);
        FlashFinished?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            StartScreenFlash(.1f);
    }
}

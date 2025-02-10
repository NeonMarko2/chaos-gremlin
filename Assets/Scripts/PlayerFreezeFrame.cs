using System.Collections;
using UnityEngine;

public class PlayerFreezeFrame : MonoBehaviour
{
    public void FreezeFrame()
    {
        StartCoroutine(Freeze());
    }

    IEnumerator Freeze()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(.25f);
        Time.timeScale = 1;
    }
}

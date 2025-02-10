using System.Collections;
using TMPro;
using UnityEngine;

public class FloorClearedMode : GameStateMode
{
    [SerializeField] private TextMeshProUGUI TextMesh;
    [SerializeField] private Sequence CapLower;

    public override void OnMode()
    {
        GlobalStats.FloorsCleared += 1;
        GlobalStats.EnemyHpScalingModifier += .1f;
        CapLower.LoadSequence();
        StartCoroutine(PlayFloorClearedSequence());
    }

    IEnumerator PlayFloorClearedSequence()
    {
        TextMesh.text = "Floor Cleared!";
        yield return new WaitForSeconds(2f);
        TextMesh.text = "";
    }
}

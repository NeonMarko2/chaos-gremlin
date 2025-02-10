using UnityEngine;

public class ResetGame : MonoBehaviour
{

    public void RestartGame()
    {
        GlobalStats.PlayerSpeed = 4;
        GlobalStats.PoisonTickrate = .5f;
        GlobalStats.PoisonSize = 1.5f;
        GlobalStats.EnemyHpScalingModifier = 1;

        GlobalStats.DamageDealt = 0;
        GlobalStats.EnemiesKilled = 0;
        GlobalStats.FloorsCleared = 0;

        PlayerController.Instance.GetComponent<Health>().HP = 3;
    }

}

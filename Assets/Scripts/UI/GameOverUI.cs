using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Floor;
    [SerializeField] private TextMeshProUGUI EnemiesKilled;
    [SerializeField] private TextMeshProUGUI DamageDealt;
    [SerializeField] private TextMeshProUGUI Score;

    public void ShowUI()
    {
        Floor.text = $"Floor {GlobalStats.FloorsCleared}";
        EnemiesKilled.text = $"Enemies killed: {GlobalStats.EnemiesKilled}";
        DamageDealt.text = $"Damage dealt: {GlobalStats.DamageDealt}";
        Score.text = $"Score: {GlobalStats.FloorsCleared*100+GlobalStats.EnemiesKilled*3+GlobalStats.DamageDealt}";
        gameObject.SetActive(true);
    }

    public void HideUI()
    {
        gameObject.SetActive(false);
    }
}

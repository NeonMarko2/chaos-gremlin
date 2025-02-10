using UnityEngine;
using UnityEngine.Events;

public class EnemyHp : MonoBehaviour, IDamagable
{
    public int HP;
    public int HPIncreasePerWave;
    public UnityEvent DamageTaken;
    public UnityEvent Died;
    [SerializeField] private AnimationCurve DiedCurve;
    [SerializeField] private ParticleSystem DeathParticles;

    private void Start()
    {
        HP += Mathf.FloorToInt(HPIncreasePerWave * GlobalStats.FloorsCleared * GlobalStats.EnemyHpScalingModifier);
    }

    public void Damage(int amount)
    {
        HP -= amount;
        DamageTaken?.Invoke();

        if (amount != 9999)
            GlobalStats.DamageDealt += amount;

        if (HP < 1)
        {
            EnemyDied();
        }
    }

    public void EnemyDied()
    {
        Died?.Invoke();
        BeingFlung beingFlung = gameObject.AddComponent<BeingFlung>();
        beingFlung.SetFling(transform.position + (Vector3)Random.insideUnitCircle.normalized, DiedCurve, .5f, 0f);
        beingFlung.FlingEnded += DestroyEnemy;
        GameManager.Instance.GetComponent<CombatMode>().RemoveEnemy();
    }

    public void DestroyEnemy()
    {
        ParticleSystem particleSystem = Instantiate(DeathParticles);
        particleSystem.transform.position = transform.position;
        particleSystem.Emit(4);
        Destroy(particleSystem, 4);
        Destroy(gameObject);
    }
}

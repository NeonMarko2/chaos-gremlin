using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    private CombatMode CombatMode;
    public bool DoSpawning;

    [SerializeField] private float SpawnFrequencyMax;
    [SerializeField] private float SpawnFrequencyMin;
    private float SpawnTimer;

    private void Awake()
    {
        CombatMode = GameManager.Instance.GetComponent<CombatMode>();

        CombatMode.StartSpawning += () =>
        {
            DoSpawning = true;
        };
        CombatMode.StopSpawning += () =>
        {
            DoSpawning = false;
            KillAllEnemies();
        };
    }

    public void KillAllEnemies()
    {
        foreach (Transform child in transform)
        {
            if(child.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.Damage(9999);
            }
            else
            {
                Destroy(child.gameObject);
            }
        }
    }

    void Update()
    {
        if (!DoSpawning)
            return;

        SpawnTimer -= Time.deltaTime;

        if (SpawnTimer > 0)
            return;

        SpawnTimer = Random.Range(SpawnFrequencyMin, SpawnFrequencyMax);

        GameObject enemy = Instantiate(Enemy);
        enemy.transform.position = Random.insideUnitCircle.normalized*4;
        enemy.transform.SetParent(transform);
    }
}

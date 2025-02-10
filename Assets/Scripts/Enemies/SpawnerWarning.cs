using UnityEngine;

public class SpawnerWarning : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private float WarningDuration;
    private float WarningTimer;

    private void Start()
    {
        WarningTimer = WarningDuration;
    }

    void Update()
    {
        WarningTimer -= Time.deltaTime;

        if (WarningTimer > 0)
            return;

        GameObject enemy = Instantiate(Enemy[Random.Range(0, Enemy.Length)]);
        enemy.transform.position = transform.position;
        enemy.transform.SetParent(transform.parent);
        Destroy(gameObject);
    }
}

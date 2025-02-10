using UnityEngine;

public class PoisonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PoisonPrefab;

    [SerializeField] private Transform GasParent;

    [SerializeField] private float SpawnFrequency;
    private float SpawnTimer;
    [SerializeField] private ParticleSystem PoisonParticles;

    private void Awake()
    {
        GameManager.Instance.GameStateChanged += GameStateChanged;
    }

    private void GameStateChanged(GameState state)
    {
        if(state == GameState.Playing)
        {
            enabled = true;
        }
        if (state == GameState.FloorCleared)
        {
            enabled = false;
        }
        if (state == GameState.GameOver)
        {
            PoisonParticles.Clear();
            enabled = false;
        }
    }

    void Update()
    {
        PoisonParticles.startSize = GlobalStats.PoisonSize;
        SpawnTimer -= Time.deltaTime;

        if (SpawnTimer > 0)
            return;

        GameObject poison = Instantiate(PoisonPrefab);
        poison.transform.localScale = Vector2.one*GlobalStats.PoisonSize;
        poison.transform.position = transform.position;
        SpawnTimer += SpawnFrequency;
        poison.transform.parent = GasParent;
    }

    private void OnDisable()
    {
        PoisonParticles.Clear();
        PoisonParticles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        PoisonParticles.gameObject.SetActive(true);
    }
}

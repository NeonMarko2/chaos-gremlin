using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Movement Movement;
    private Throw Throw;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Throw = GetComponent<Throw>();
        Movement = GetComponent<Movement>();

        GameManager.Instance.GameStateChanged += GameStateChanged;
    }

    private void GameStateChanged(GameState state)
    {
        if(state == GameState.GameOver)
        {
            Movement.enabled = false;
            enabled = false;
        }
        else if (state == GameState.Playing)
        {
            Movement.enabled = true;
            enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement.SetMoveVector(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        Movement.Speed = GlobalStats.PlayerSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
            Throw.ThrowEnemy();
    }
}

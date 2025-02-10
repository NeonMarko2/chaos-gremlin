using UnityEngine;

public abstract class GameStateMode : MonoBehaviour
{
    [SerializeField] private GameState ActivationState;
    void Awake()
    {
        GameManager.Instance.GameStateChanged += (gameState) =>
        {
            if (gameState == ActivationState)
                OnMode();
        };
    }

    public abstract void OnMode();
}

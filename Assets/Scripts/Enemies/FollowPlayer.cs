using UnityEngine;

public class FollowPlayer : MonoBehaviour, IFlungable
{
    private Movement Movement;

    public void FlungEnded()
    {
        enabled = true;
        Camera.main.transform.parent.GetComponent<CameraShake>().SetShake(.2f);
    }

    public void FlungStarted()
    {
        enabled = false;
        Movement.SetMoveVector(Vector2.zero);
    }

    private void Start()
    {
        Movement = GetComponent<Movement>();
        GameManager.Instance.GameStateChanged += GameStateChanged;
    }

    private void GameStateChanged(GameState state)
    {
        if(state == GameState.GameOver)
        {
            GetComponent<IDamagable>().Damage(9999);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.GameStateChanged -= GameStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        Movement.SetMoveVector(PlayerController.Instance.transform.position - transform.position);
    }
}

using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Movement Movement;
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        GameManager.Instance.GameStateChanged += GameStateChanged;
    }

    private void GameStateChanged(GameState state)
    {
        if(state == GameState.GameOver)
        {
            Animator.SetBool("Died", true);
        }
        if (state == GameState.Playing)
        {
            Animator.SetBool("Died", false);
        }
    }

    void Update()
    {
        Animator.SetFloat("Speed", Movement.MoveVector.sqrMagnitude);

        if(Movement.MoveVector.x < 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if(Movement.MoveVector.x > 0)
        {
            SpriteRenderer.flipX = true;
        }
    }
}

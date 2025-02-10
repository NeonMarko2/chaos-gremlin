using UnityEngine;

public class EnemyAnimator : MonoBehaviour, IFlungable
{
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(transform.position.x < PlayerController.Instance.transform.position.x)
        {
            SpriteRenderer.flipX = true;
        }
        else
        {
            SpriteRenderer.flipX = false;
        }
    }

    public void FlungEnded()
    {
        Animator.SetBool("Flung", false);
    }

    public void FlungStarted()
    {
        print("flung");
        Animator.SetBool("Flung", true);
    }
}

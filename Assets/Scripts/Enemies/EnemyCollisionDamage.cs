using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour, IFlungable
{
    public Collider2D Collider2D;

    public void FlungEnded()
    {
        Collider2D.excludeLayers = LayerMask.NameToLayer("Player");
    }

    public void FlungStarted()
    {
        Collider2D.excludeLayers = ~(LayerMask.NameToLayer("Player"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Player")
        {
            collision.collider.gameObject.GetComponent<IDamagable>().Damage(1);
        }
    }
}

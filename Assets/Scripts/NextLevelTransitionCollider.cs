using UnityEngine;
using UnityEngine.Events;

public class NextLevelTransitionCollider : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision?.Invoke();
    }
}

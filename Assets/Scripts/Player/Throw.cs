using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private float ThrowDistance;
    [SerializeField] private float GrabRange;

    [SerializeField] private GameObject ClosestEnemy;
    [SerializeField] private AnimationCurve ThrowCurve;

    public float CooldownDuration;
    public float CooldownTimer { get; private set; }

    void Update()
    {
        if (CooldownTimer > 0)
        {
            CooldownTimer -= Time.deltaTime;
            return;
        }

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, GrabRange, 1<<7);

        Collider2D closestCollider = null;
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < collider2Ds.Length; i++)
        {
            float distance = (collider2Ds[i].transform.position - transform.position).sqrMagnitude;
            if (distance > closestDistance)
                continue;
            closestCollider = collider2Ds[i];
            closestDistance = distance;
        }

        if (closestCollider == null)
        {
            if (ClosestEnemy != null)
            {
                ClosestEnemy.GetComponentInChildren<IOutliner>().OutlineToggle(false);
            }
            ClosestEnemy = null;
        }
        else
        {
            if (ClosestEnemy == closestCollider.gameObject)
                return;

            if(ClosestEnemy != null)
            {
                ClosestEnemy.GetComponentInChildren<IOutliner>().OutlineToggle(false);
            }

            ClosestEnemy = closestCollider.gameObject;
            ClosestEnemy.GetComponentInChildren<IOutliner>().OutlineToggle(true);
        }
    }

    public void ThrowEnemy()
    {
        if (ClosestEnemy)
        {
            CooldownTimer = CooldownDuration;
            ClosestEnemy.AddComponent<BeingFlung>().SetFling(transform.position + (transform.position-ClosestEnemy.transform.position).normalized*ThrowDistance, ThrowCurve, .85f, .15f);
            ClosestEnemy.GetComponentInChildren<IOutliner>().OutlineToggle(false);
            ClosestEnemy = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, GrabRange);
    }
}

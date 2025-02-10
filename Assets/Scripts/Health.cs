using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamagable
{
    public int HP;
    public UnityEvent DamageTaken;
    public UnityEvent Healed;
    public UnityEvent Died;

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            HP -= amount;
            Healed?.Invoke();
            return;
        }

        HP -= amount;
        DamageTaken?.Invoke();

        if(HP < 1)
        {
            Died?.Invoke();
            GameManager.Instance.SetGameState(GameState.GameOver);
        }
    }
}

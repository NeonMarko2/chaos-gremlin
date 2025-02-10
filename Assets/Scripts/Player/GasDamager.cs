using System.Collections.Generic;
using UnityEngine;

public class GasDamager : MonoBehaviour
{
    public class Target
    {
        public Collider2D Collider2D;
        public float TickTimer;
    }

    public float PoisonSize = 1.5f;
    public float TickFrequency = .5f;

    public List<Target> Enemies = new List<Target>();

    public void AddTarget(Collider2D collider2D)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].Collider2D == collider2D)
                return;
        }

        Enemies.Add(new Target { Collider2D = collider2D, TickTimer = TickFrequency });
    }

    public void RemoveTarget(Collider2D collider2D)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i].Collider2D == collider2D)
            {
                Enemies.RemoveAt(i);
                return;
            }
        }
    }

    void Update()
    {
        PoisonSize = GlobalStats.PoisonSize;
        TickFrequency = GlobalStats.PoisonTickrate;
        for (int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].TickTimer -= Time.deltaTime;
            if (Enemies[i].TickTimer > 0)
                continue;

            if (Enemies[i].Collider2D == null)
            {
                Enemies.RemoveAt(i);
                continue;
            }

            Enemies[i].TickTimer = TickFrequency;
            Enemies[i].Collider2D.GetComponent<IDamagable>()?.Damage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Added");
        AddTarget(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("removed");
        RemoveTarget(collision);
    }
}

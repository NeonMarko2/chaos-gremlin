using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCooldownUI : MonoBehaviour
{
    [SerializeField] private Throw Throw;
    [SerializeField] private Image Bar;

    void Update()
    {
        Bar.fillAmount = Throw.CooldownTimer/Throw.CooldownDuration;
    }
}

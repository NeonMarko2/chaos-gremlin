using UnityEngine;
using UnityEngine.Events;

public class FunctionSequence : SequenceAction
{
    [SerializeField] private UnityEvent Functions;

    public override void Play(Sequence sequence)
    {
        Functions?.Invoke();
        sequence.PlaySequence();
    }
}

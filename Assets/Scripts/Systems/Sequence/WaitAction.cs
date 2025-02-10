using UnityEngine;

public class WaitAction : SequenceAction
{
    [SerializeField] private float Duration;
    private float Timer;

    private Sequence Sequence;

    public override void Play(Sequence sequence)
    {
        Sequence = sequence;
        Timer = Duration;
        gameObject.SetActive(true);
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            gameObject.SetActive(false);
            Sequence.PlaySequence();
        }
    }
}

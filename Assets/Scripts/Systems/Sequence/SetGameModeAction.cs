using JetBrains.Annotations;
using UnityEngine;

public class SetGameModeAction : SequenceAction
{
    [SerializeField] private GameState GameState;

    public override void Play(Sequence sequence)
    {
        GameManager.Instance.SetGameState(GameState);
        sequence.PlaySequence();
    }
}

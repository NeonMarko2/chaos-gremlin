using System;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    [SerializeField] private List<SequenceAction> Actions = new List<SequenceAction>();
    private int CurrentIndex;

    public event Action Finished;

    public void LoadSequence()
    {
        Actions.Clear();

        foreach (Transform child in transform)
        {
            Actions.Add(child.GetComponent<SequenceAction>());
        }
        CurrentIndex = 0;
        PlaySequence();
    }

    public void PlaySequence()
    {
        if (CurrentIndex >= Actions.Count)
            return;

        SequenceAction action = Actions[CurrentIndex];
        CurrentIndex++;
        action.Play(this);

        if (CurrentIndex >= Actions.Count)
            Finished?.Invoke();
    }
}
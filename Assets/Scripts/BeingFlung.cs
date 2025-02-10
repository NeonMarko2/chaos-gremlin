using System;
using UnityEngine;

public class BeingFlung : MonoBehaviour
{
    private Vector2 PositionToFlingTo;
    private Vector2 StartPosition;

    private float FlungTime = 0;

    private AnimationCurve AnimationCurve;

    private float ThrowLength;

    private float DurationBeforeFling = .2f;
    private float TimeBeforeFling;

    public event Action FlingEnded;

    public void SetFling(Vector2 end, AnimationCurve throwCurve, float throwLength, float delay)
    {
        DurationBeforeFling = delay;
        StartPosition = transform.position;
        ThrowLength = throwLength;
        PositionToFlingTo = end;
        AnimationCurve = throwCurve;

        TimeBeforeFling = DurationBeforeFling;

        IFlungable[] flungables = GetComponentsInChildren<IFlungable>();

        for (int i = 0; i < flungables.Length; i++)
        {
            flungables[i].FlungStarted();
        }
    }

    void Update()
    {
        TimeBeforeFling -= Time.deltaTime;
        if (TimeBeforeFling > 0)
            return;

        transform.position = Vector2.Lerp(StartPosition, PositionToFlingTo, FlungTime)+new Vector2(0, AnimationCurve.Evaluate(FlungTime));
        FlungTime += Time.deltaTime/ThrowLength;

        if(FlungTime >= 1)
        {
            IFlungable[] flungables = GetComponentsInChildren<IFlungable>();

            for (int i = 0; i < flungables.Length; i++)
            {
                flungables[i].FlungEnded();
            }
            FlingEnded?.Invoke();
            Destroy(this);
        }
    }
}

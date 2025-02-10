using UnityEngine;

public class LerpAction : SequenceAction
{
    [SerializeField] private Transform Target;
    [SerializeField] private Rigidbody2D RigidBodyTarget;
    [SerializeField] private Transform StartTransform;
    [SerializeField] private Transform EndTransform;
    [SerializeField] private Vector3 StartPos;
    [SerializeField] private Vector3 EndPos;

    [SerializeField] private AnimationCurve XOffset;
    [SerializeField] private AnimationCurve YOffset;

    [SerializeField] private float LerpLength;
    [SerializeField] private float LerpStart;
    [SerializeField] private float LerpCutoff;
    [SerializeField] private AnimationCurve LerpCurveSpeed;

    private float LerpTime;

    private Sequence Sequence;

    public override void Play(Sequence sequence)
    {
        Sequence = sequence;
        gameObject.SetActive(true);

        if(LerpCurveSpeed.length == 0)
            LerpCurveSpeed = AnimationCurve.Linear(0, 0, 1, 1);

        LerpTime = LerpStart;
        if (StartTransform)
            StartPos = StartTransform.position;
        if (EndTransform)
            EndPos = EndTransform.position;
    }

    void Update()
    {
        LerpTime += Time.deltaTime/LerpLength;

        float xOffset = XOffset.Evaluate(LerpTime);
        float yOffset = YOffset.Evaluate(LerpTime);

        if (Target)
            Target.position = Vector3.Lerp(StartPos, EndPos, LerpTime) + new Vector3(xOffset, yOffset);
        if (RigidBodyTarget)
            RigidBodyTarget.MovePosition(Vector3.Lerp(StartPos, EndPos, LerpTime) + new Vector3(xOffset, yOffset));

        if(LerpCutoff > 0 && LerpTime >= LerpCutoff)
        {
            Sequence.PlaySequence();
            gameObject.SetActive(false);
            return;
        }

        if (LerpTime > 1)
        {
            gameObject.SetActive(false);
            Sequence.PlaySequence();
        }
    }
}

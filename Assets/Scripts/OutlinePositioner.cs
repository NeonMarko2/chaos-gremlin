using UnityEngine;

public class OutlinePositioner : MonoBehaviour, IOutliner
{
    [SerializeField] private SpriteRenderer SpriteToTarget;
    private SpriteRenderer SpriteRenderer;

    public void OutlineToggle(bool value)
    {
        SpriteRenderer.enabled = value;
    }

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        SpriteRenderer.sprite = SpriteToTarget.sprite;
        SpriteRenderer.flipX = SpriteToTarget.flipX;
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public Vector2 MoveVector { get; private set; }
    public float Speed;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetMoveVector(Vector2 moveVector)
    {
        MoveVector = moveVector;
    }

    private void FixedUpdate()
    {
        Rigidbody2D.MovePosition(transform.position + (Vector3)MoveVector.normalized * Speed * Time.fixedDeltaTime);
    }
}

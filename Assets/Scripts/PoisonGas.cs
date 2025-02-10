using UnityEngine;

public class PoisonGas : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 4);
    }
}

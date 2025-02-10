using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float ShakeStrength;

    [SerializeField] private float ShakeInterval;
    private float ShakeTime;

    public void SetShake(float shakeStrength)
    {
        ShakeStrength = shakeStrength;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ShakeStrength = .35f;
        }

        ShakeTime -= Time.deltaTime;
        if (ShakeTime > 0)
            return;

        transform.position = new Vector3(Mathf.Cos(Time.time*10), Mathf.Sin(Time.time*10)) * ShakeStrength;
        ShakeStrength *= .5f;
        ShakeTime = ShakeInterval;
    }
}

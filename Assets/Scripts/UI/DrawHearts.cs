using UnityEngine;

public class DrawHearts : MonoBehaviour
{
    [SerializeField] private GameObject Heart;
    [SerializeField] private Health PlayerHP;

    private void Start()
    {
        SetHearts();
    }

    public void SetHearts()
    {
        foreach (Transform heart in transform)
        {
            Destroy(heart.gameObject);
        }
        for (int i = 0; i < PlayerHP.HP; i++)
        {
            GameObject heart = Instantiate(Heart);
            heart.transform.SetParent(transform);
        }
    }
}

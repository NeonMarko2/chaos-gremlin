using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSelection : MonoBehaviour
{
    [SerializeField] private Image Icons;
    [SerializeField] private Image[] UpgradeImages;
    [SerializeField] private string[] UpgradeDescriptions;
    [SerializeField] private int[] UpgradeIds;
    private int CurrentSelection = 1;

    [SerializeField] private TextMeshProUGUI UpgradeText;

    [SerializeField] private float TransitionDuration;
    private Vector2 StartX;
    private Vector2 TargetX;
    private float LerpTime;
    private bool DoLerp;

    public void SetUpgrades(ShopMode.UpgradeInfo[] upgradeInfo, int[] ids)
    {
        for (int i = 0; i < ids.Length; i++)
        {
            UpgradeImages[i].sprite = upgradeInfo[i].Icon;
            UpgradeDescriptions[i] = upgradeInfo[i].Description;
        }
        UpgradeIds = ids;
        SetCurrentUpgrade(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SetCurrentUpgrade(CurrentSelection-1);
        else if (Input.GetKeyDown(KeyCode.D))
            SetCurrentUpgrade(CurrentSelection+1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.GetComponent<ShopMode>().GetUpgrade(UpgradeIds[CurrentSelection]);
            gameObject.SetActive(false);
        }

        if (!DoLerp)
            return;
        
        Icons.rectTransform.anchoredPosition = Vector2.Lerp(StartX, TargetX, LerpTime);
        LerpTime += Time.deltaTime/TransitionDuration;

        if(LerpTime >= 1)
            DoLerp = false;
    }

    public void SetCurrentUpgrade(int selection)
    {
        selection = Mathf.Clamp(selection, 0, 2);

        //if (CurrentSelection == selection)
        //    return;

        CurrentSelection = selection;

        DoLerp = true;
        LerpTime = 0;
        StartX = Icons.rectTransform.anchoredPosition;
        TargetX = new Vector2(300 - CurrentSelection * 300, Icons.rectTransform.anchoredPosition.y);

        UpgradeText.text = UpgradeDescriptions[CurrentSelection];
    }
}

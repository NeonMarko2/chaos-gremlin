using System;
using UnityEngine;

public class ShopMode : GameStateMode
{
    public ShopSelection ShopSelection;
    private GameManager GameManager;
    [SerializeField] private Sequence LandingSequence;

    [Serializable]
    public struct UpgradeInfo
    {
        public string Description;
        public Sprite Icon;
    }
    
    public UpgradeInfo[] Upgrades;

    private void Start()
    {
        GameManager = GameManager.Instance;
    }

    public override void OnMode()
    {
        ShopSelection.gameObject.SetActive(true);
        int[] ids = { UnityEngine.Random.Range(0, Upgrades.Length), UnityEngine.Random.Range(0, Upgrades.Length), UnityEngine.Random.Range(0, Upgrades.Length) };
        UpgradeInfo[] upgradeInfos = { Upgrades[ids[0]], Upgrades[ids[1]], Upgrades[ids[2]] };

        ShopSelection.SetUpgrades(upgradeInfos, ids);
    }

    public void GetUpgrade(int index)
    {
        print(index);
        switch (index)
        {
            case 0:
                PlayerController.Instance.GetComponent<IDamagable>().Damage(-1);
                break;
            case 1:
                GlobalStats.PlayerSpeed += 1;
                break;
            case 2:
                GlobalStats.PoisonSize += .5f;
                break;
            case 3:
                GlobalStats.PoisonTickrate -= .1f;
                break;
            case 4:
                GlobalStats.PoisonDamage += 1;
                break;
            default:
                break;
        }

        LandingSequence.LoadSequence();
        ShopSelection.gameObject.SetActive(false);
    }
}

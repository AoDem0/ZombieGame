using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public string upgradeName;
    public int currentLevel;
    public List<int> upgradeCost;
    public List<float> upgradeParameters;

}

public class upgradeManager : MonoBehaviour
{
    [SerializeField] private EventsList events;
    [SerializeField] private MoneyScript moneySC;
    [SerializeField] private int index;
    public List<Upgrade> allUpgrades;
    private void OnEnable()
    {
        EventsList.OnUpgradeInteraction += MatchUpgrade;
    }

    private void OnDisable()
    {
        EventsList.OnUpgradeInteraction -= MatchUpgrade;
    }

    void MatchUpgrade(string name)
    {
        for (int i = 0; i < allUpgrades.Count; i++)
        {
            if (name == allUpgrades[i].upgradeName)
            {
                Debug.Log("Matched upgrade");
                BuyUpgrade(i);
            }
        }
    }
    void BuyUpgrade(int index)
    {
        Upgrade upgrade = allUpgrades[index];

        if (upgrade.currentLevel < upgrade.upgradeCost.Count &&
            upgrade.currentLevel < upgrade.upgradeParameters.Count &&
            moneySC.money >= upgrade.upgradeCost[upgrade.currentLevel])
        {
            // Zabranie kasy
            events.PayMoney(upgrade.upgradeCost[upgrade.currentLevel]);

            // Event zmiany parametrów broni 
            events.UpgradeChange(upgrade.upgradeName, upgrade.upgradeParameters[upgrade.currentLevel]);

            // Zwiększenie poziomu
            upgrade.currentLevel += 1;
        }
        
    }
    



}

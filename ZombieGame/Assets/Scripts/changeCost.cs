using TMPro;
using UnityEngine;

public class changeCost : MonoBehaviour
{
    [SerializeField] private int upgradeIndex;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private upgradeManager upgMan;

    void Start()
    {
        text.text = "$ " + upgMan.allUpgrades[upgradeIndex].upgradeCost[upgMan.allUpgrades[upgradeIndex].currentLevel].ToString();
    }
    void Update()
{
    if (upgradeIndex >= 0 && upgradeIndex < upgMan.allUpgrades.Count)
    {
        var upgrade = upgMan.allUpgrades[upgradeIndex];

        if (upgrade.currentLevel >= 0 && upgrade.currentLevel < upgrade.upgradeCost.Count)
        {
            text.text = "$ " + upgrade.upgradeCost[upgrade.currentLevel].ToString();
        }
        else
        {
            text.text = " "; // Nie ma więcej upgrade'ów
        }
    }
}


}

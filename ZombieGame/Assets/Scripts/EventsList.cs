using System;
using UnityEngine;

public class EventsList : MonoBehaviour
{
    public static Action OnEnemyDeath;
    public static Action<string> OnUpgradeInteraction;
    public static Action<string, float> OnUpgradeChange;
    public static Action<int> OnPayMoney;

    public void EnemyDeath()
    {
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath.Invoke();
        }
    }
    public void UpgradeInteraction(string name)
    {
        OnUpgradeInteraction.Invoke(name);
    }

    public void UpgradeChange(string name, float upgradeParameter)
    {
        OnUpgradeChange.Invoke(name, upgradeParameter);
    }

    public void PayMoney(int amount)
    {
        OnPayMoney.Invoke(amount);
    }

}

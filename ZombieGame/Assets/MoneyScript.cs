using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public int money = 0;
    [SerializeField] private int addedMoney = 3;
    [SerializeField] private EventsList events;
    [SerializeField] private TextMeshProUGUI textUI;
    private void OnEnable()
    {
        EventsList.OnEnemyDeath += AddMoney;
    }

    private void OnDisable()
    {
        EventsList.OnEnemyDeath -= AddMoney;
    }

    private void AddMoney()
    {
        money = money + addedMoney;
        textUI.text = money.ToString();
        Debug.Log("Dodano kase");
    }


}

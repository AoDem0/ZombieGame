using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public int money = 0;
    [SerializeField] private int addedMoney = 3;
    [SerializeField] private EventsList events;
    [SerializeField] private TextMeshProUGUI textUI;
    void Start()
    {
        textUI.text = money.ToString();
    }
    private void OnEnable()
    {
        EventsList.OnEnemyDeath += AddMoney;
        EventsList.OnPayMoney += changeMoney;
    }

    private void OnDisable()
    {
        EventsList.OnEnemyDeath -= AddMoney;
        EventsList.OnPayMoney -= changeMoney;
    }

    private void AddMoney()
    {
        money = money + addedMoney;
        textUI.text = money.ToString();
        //Debug.Log("Dodano kase");
    }
    private void changeMoney(int amount) {
        money -= amount;
        textUI.text = money.ToString();
    }


}

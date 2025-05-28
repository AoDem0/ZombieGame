using UnityEngine;
using UnityEngine.UI;

public class showEnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyScript enemy;
    [SerializeField] Slider slider;

    void Start()
    {
        enemy = GetComponentInParent<EnemyScript>();
    }

    void Update()
    {
        slider.value = (float)enemy.currentEnemyHealth/enemy.maxEnemyHealth;
    }
}

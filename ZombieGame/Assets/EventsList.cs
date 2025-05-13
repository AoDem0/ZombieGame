using System;
using UnityEngine;

public class EventsList : MonoBehaviour
{
    public static Action OnEnemyDeath;

    public void EnemyDeath(){
        if (OnEnemyDeath != null){
            OnEnemyDeath.Invoke();
        }
    }

}

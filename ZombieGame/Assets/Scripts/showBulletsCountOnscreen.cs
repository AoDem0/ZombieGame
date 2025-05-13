using TMPro;
using UnityEngine;

public class showBulletsCountOnscreen : MonoBehaviour
{
    [SerializeField] GunScript gunScript;
    [SerializeField] TextMeshProUGUI text;

    
    void Update()
    {
        text.text = gunScript.currentBulletsAmount + " / " + gunScript.maxBulletsAmount;
    }
}

using UnityEngine;

public class homeManager : MonoBehaviour
{
    public int homeCurrentHP;
    public int homeMaxHP;
    public void takeDMGHome()
    {
        homeCurrentHP -= 10;
        /*slider.value = (float)homeCurrentHP / homeMaxHP;
        if (homeCurrentHP <= 0)
        {
            EndGame();
        }*/
    }
}

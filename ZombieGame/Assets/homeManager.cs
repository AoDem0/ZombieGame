using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class homeManager : MonoBehaviour
{
    public int homeCurrentHP;
    public int homeMaxHP;
    [SerializeField] private Slider slider;
    void Start()
    {
        slider.value = (float)homeCurrentHP / homeMaxHP;
    }
    public void takeDMGHome()
    {
        homeCurrentHP -= 10;
        slider.value = (float)homeCurrentHP / homeMaxHP;
        if (homeCurrentHP <= 0)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        SceneManager.LoadScene("death2");
    }
}

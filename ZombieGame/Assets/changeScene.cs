using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void GameStart()
    {   
        SceneManager.LoadScene("game");
       
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

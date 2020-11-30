using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void gameRestart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart");
    }
    public void gameEnd()
    {
        Application.Quit();
        Debug.Log("GameOver");
    }
}

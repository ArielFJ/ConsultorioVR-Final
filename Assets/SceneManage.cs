using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadScene() 
    {
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        
        //resultados.SetActive(false);
    }
    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("CERRO");
    }

    public void LoadResultsScene()
    {
        SceneManager.LoadScene(1);
    }

    private void OnDestroy()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
            Destroy(FindObjectOfType<MainMenu>().gameObject);
    }
}

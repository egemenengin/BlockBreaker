using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int curSceneInd = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneInd + 1); 

    }
    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

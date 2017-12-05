using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
  
public void Startgame()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void EndGame()
    {
        Debug.Log("EndGame");
        Application.Quit();
    }
    public void Retry()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

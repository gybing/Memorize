using UnityEngine;
using UnityEngine.SceneManagement;


public class gameoverClick : MonoBehaviour {

    public void Restart()
    {
        SceneManager.LoadScene("game");
    }

    public void Out()
    {
        Application.Quit();
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginManager : MonoBehaviour {
     
    public void OnClickBegin() {
        SceneManager.LoadScene("game");

    }
    public void OnClickHelp()
    {
        SceneManager.LoadScene("help");
    }
    public void OnClickOut()
    {
        Application.Quit();
    }


}

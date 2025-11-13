using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Slavik Max, 11:45PM 10/26/25, Using buttons for end game screen.
/// </summary>
public class EndScreenM : MonoBehaviour
{
    public void QuitGame() // quits game
    {
        Application.Quit();
    }
    /// <summary>
    /// Changes to the scene soon.
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void SwitchScene(int sceneIndex) //switch scene
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}

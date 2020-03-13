using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void QuitGame()
    {
        Application.Quit();
        print("Quit Game");
    }
    public void InGameSettings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Need something that pauses all progress when clicked
    }
    public void BackToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SaveGame()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public static int level;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
        level= 1;
    }

    public void Level2()
    {
        SceneManager.LoadScene(3);
        level= 2;
    }

    public void Level3()
    {
        SceneManager.LoadScene(4);
        level= 3;
    }

    public void Rewards()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using UnityEngine;

public class Exit : MonoBehaviour
{
    void doExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}

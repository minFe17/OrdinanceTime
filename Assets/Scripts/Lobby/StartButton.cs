using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("IngameScene");
    }
}
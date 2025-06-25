using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKey : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadScene("IngameScene");
    }
}
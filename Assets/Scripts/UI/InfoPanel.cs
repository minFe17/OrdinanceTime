using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    void Start()
    {
        Invoke("HideInfo", 7f);
    }

    void HideInfo()
    {
        this.gameObject.SetActive(false);
    }
}